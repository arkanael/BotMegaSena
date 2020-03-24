using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Informe o número do concurso.");
            string numeroConcurso = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(numeroConcurso))
            {
                numeroConcurso = "2231";

            }

            string url = @"http://www1.caixa.gov.br/loterias/loterias/megasena/megasena_pesquisa_new.asp?submeteu=sim&opcao=concurso&txtConcurso=" + numeroConcurso;
            string html;

            using (WebClient webclient = new WebClient())
            {
                webclient.Headers["Cookie"] = "security=true";
                html = webclient.DownloadString(url);
            }

            html = html.Replace("<span> class=\"num_sorteio\"><ul>", "");
            html = html.Replace("</ul></span>", "");
            html = html.Replace("</li>", "");

            string[] vetor = Regex.Split(html, "<li>");
            List<int> resultado = new List<int>();

            resultado.Add(int.Parse(vetor[1]));
            resultado.Add(int.Parse(vetor[2]));
            resultado.Add(int.Parse(vetor[3]));
            resultado.Add(int.Parse(vetor[4]));
            resultado.Add(int.Parse(vetor[5]));
            resultado.Add(int.Parse(vetor[6].Substring(0, 2)));

            Console.WriteLine($"Concurso Selecionado: {numeroConcurso}");
            Console.Write("Resultado: ");
            resultado.OrderBy(x => x).ToList().ForEach(resultadoMegaSena => 
            {
                Console.Write($"{resultadoMegaSena} ");
            });

            Console.ReadKey();
        }
    }
}
