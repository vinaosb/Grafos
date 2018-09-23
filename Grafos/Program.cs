using System;
using System.Collections.Generic;

namespace Grafos
{
    class Program
    {
        public static Grafo G { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            G = new Grafo();

            G.AddVertice(5401);
            G.AddVertice(5402);
            G.AddVertice(5403);
            G.AddVertice(5404);
            G.AddVertice(5405);
            G.AddVertice(5406);
            G.AddVertice(5407);
            G.AddVertice(5408);
            G.AddVertice(5409);
            G.AddVertice(5410);
            G.AddVertice(5411);
            G.AddVertice(5412);
            G.AddVertice(5413);
            G.AddVertice(5414);
            G.AddVertice(5415);
            G.AddVertice(5416);
            G.AddVertice(5417);
            G.AddVertice(5418);
            G.AddVertice(5419);
            G.AddVertice(5420);
            G.AddVertice(5421);
            G.AddVertice(5422);
            G.AddVertice(5423);
            G.AddVertice(5424);
            G.AddVertice(5425);
            G.AddVertice(5426);
            G.AddVertice(5427);
            G.AddVertice(5428);
            G.AddVertice(5429);
            G.AddVertice(5430);
            G.AddVertice(5431);
            G.AddVertice(5432);
            G.AddVertice(5433);
            G.AddVertice(5434);
            G.AddVertice(5453);

            G.AddVertice(5105);
            G.AddVertice(5161);
            G.AddVertice(7174);
            G.AddVertice(5512);
            G.AddVertice(5245);

            //Vermelho
            G.ConectaOrdenado(5402, 5404);
            G.ConectaOrdenado(5404, 5408);
            G.ConectaOrdenado(5404, 5410);
            G.ConectaOrdenado(5404, 5414);
            G.ConectaOrdenado(5408, 5417);
            G.ConectaOrdenado(5408, 5420);
            G.ConectaOrdenado(5408, 5423);
            G.ConectaOrdenado(5408, 5413);
            G.ConectaOrdenado(5408, 5415);
            G.ConectaOrdenado(5408, 5416);
            G.ConectaOrdenado(5410, 5412);
            G.ConectaOrdenado(5417, 5419);
            G.ConectaOrdenado(5417, 5427);
            G.ConectaOrdenado(5417, 5453);
            G.ConectaOrdenado(5427, 5433);
            G.ConectaOrdenado(5453, 5433);

            //Amarelo Claro
            G.ConectaOrdenado(5161, 7174);
            G.ConectaOrdenado(5161, 5405);
            G.ConectaOrdenado(7174, 5409);
            G.ConectaOrdenado(7174, 5420);
            G.ConectaOrdenado(5405, 5425);
            G.ConectaOrdenado(5405, 5430);
            G.ConectaOrdenado(5512, 5245);
            G.ConectaOrdenado(5512, 5409);
            G.ConectaOrdenado(5245, 5420);

            //Verde
            G.ConectaOrdenado(5403, 5429);
            G.ConectaOrdenado(5403, 5413);
            G.ConectaOrdenado(5403, 5415);
            G.ConectaOrdenado(5415, 5421);
            G.ConectaOrdenado(5421, 5426);
            G.ConectaOrdenado(5416, 5430);

            //Azul
            G.ConectaOrdenado(5105, 5406);
            G.ConectaOrdenado(5406, 5411);
            G.ConectaOrdenado(5411, 5412);
            G.ConectaOrdenado(5412, 5418);
            G.ConectaOrdenado(5412, 5424);

            //Branco
            G.ConectaOrdenado(5407, 5428);

            //Laranja
            G.ConectaOrdenado(5414, 5422);
            G.ConectaOrdenado(5414, 5418);
            G.ConectaOrdenado(5414, 5431);
            G.ConectaOrdenado(5414, 5429);

            //Roxo
            G.ConectaOrdenado(5423, 5432);



            Console.WriteLine(G.EhArvore());
            Console.WriteLine(G.EhConexo());
            var list = G.OrdenacaoTopologica();
            string temp = "";
            foreach (var l in list)
            {
                switch (l)
                {
                    case 5105:
                        temp = "EEL";
                        break;
                    case 5161:
                        temp = "MTM";
                        break;
                    case 7174:
                        temp = "MTM";
                        break;
                    case 5245:
                        temp = "MTM";
                        break;
                    case 5512:
                        temp = "MTM";
                        break;
                    default:
                        temp = "INE";
                        break;
                }
                Console.WriteLine(temp + l);
            }
            Console.ReadKey();
        }
    }
}
