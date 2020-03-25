using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Instagram.Profile
{
    public static class Instagram
    {
        public static Profile GetProfileByUser(string userName)
        {
            var profile = new Profile(userName);

            string url = @"https://www.instagram.com/" + userName + "/";

            string markup;
            using (var client = new WebClient())
            {
                markup = client.DownloadString(url);
            }

            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(markup);

            var list = html.DocumentNode.SelectNodes("//meta");

            foreach (var node in list)
            {
                string property = node.GetAttributeValue("property", "");

                if (property == "al:ios:app_name")
                    profile.IosAppName = node.GetAttributeValue("content", "");

                if (property == "al:ios:app_store_id")
                    profile.IosAppName = node.GetAttributeValue("content", "");

                if (property == "al:ios:url")
                    profile.IosAppName = node.GetAttributeValue("content", "");

                if (property == "al:android:app_name")
                    profile.IosAppName = node.GetAttributeValue("content", "");

                if (property == "al:android:app_store_id")
                    profile.IosAppName = node.GetAttributeValue("content", "");

                if (property == "al:android:url")
                    profile.IosAppName = node.GetAttributeValue("content", "");
                
                if (property == "og:type")
                    profile.IosAppName = node.GetAttributeValue("content", "");

                if (property == "og:image")
                    profile.IosAppName = node.GetAttributeValue("content", "");

                if (property == "og:title")
                    profile.IosAppName = node.GetAttributeValue("content", "");

                if (property == "og:description")
                    profile.IosAppName = node.GetAttributeValue("content", "");

                if (property == "og:url")
                    profile.IosAppName = node.GetAttributeValue("content", "");
            }

            return profile;
        }
    }
}
