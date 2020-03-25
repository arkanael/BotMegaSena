using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Instagram.Profile
{
    class Program
    {
        static void Main(string[] args)
        {
            Instagram.GetProfileByUser("i.love.code");

            Console.ReadKey();
        }
    }
}
