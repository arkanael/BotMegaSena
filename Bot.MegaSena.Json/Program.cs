using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bot.MegaSena.Json
{
    class Program
    {
        static void Main(string[] args)
        {
            string url;

            Console.WriteLine("Informe o número do concurso.");
            string numeroConcurso = Console.ReadLine();

            string html;

            if (string.IsNullOrWhiteSpace(numeroConcurso))
            {
                url = @"http://loterias.caixa.gov.br/wps/portal/loterias/landing/megasena/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbwMPI0sDBxNXAOMwrzCjA0sjIEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wNnUwNHfxcnSwBgIDUyhCvA5EawAjxsKckMjDDI9FQE-F4ca/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0KO6H80AU71KG7J0072/res/id=buscaResultado/c=cacheLevelPage/=/?timestampAjax=1581042977734";

            }
            else
            {
                url = @"http://loterias.caixa.gov.br/wps/portal/loterias/landing/megasena/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbwMPI0sDBxNXAOMwrzCjA0sjIEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wNnUwNHfxcnSwBgIDUyhCvA5EawAjxsKckMjDDI9FQE-F4ca/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0KO6H80AU71KG7J0072/res/id=buscaResultado/c=cacheLevelPage/=/?timestampAjax=1581042832097&concurso=" + numeroConcurso;
            }
            
            string json;

            using (WebClient webclient = new WebClient())
            {
                html = webclient.DownloadString(url);
                json = webclient.DownloadString(url);
            }

            
            var resultado = JsonConvert.DeserializeObject<ResultadoMegaSena>(json);
            
            if (resultado.mensagens.Contains("Concurso inexistente. Por favor, confira numeração digitada"))
            {
                Console.WriteLine("erro");
            }
            Console.WriteLine($"Concurso número: {resultado.concurso} ");
            Console.WriteLine($"Resultado: {resultado.ResultadoOrdenado}");
            Console.WriteLine($"Total de Ganhadores: {resultado.ganhadores} ");

            Console.ReadKey();

        }
    }
}
