using System;

namespace Suporte_ao_cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            
            while(true)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine("====[Selecione a opção desejada]=====");
                Console.WriteLine("=====================================");
                Console.WriteLine("1 - Entrar como cliente");
                Console.WriteLine("2 - Entrar como suporte");
                Console.WriteLine("3 - Encerrar");

                Voltar:
                Console.Write("\nOpção desejada: ");
                string teste = Console.ReadLine();
                if (teste == "" || (teste != "1" && teste != "2" && teste != "3"))
                {
                    Console.WriteLine("Você precisa digitar uma opção válida!");
                    goto Voltar;
                }
                opcao = int.Parse(teste);

                if(opcao == 1)
                {
                    Console.WriteLine("Você entrou na área do cliente");
                }
                else if(opcao == 2)
                {
                    Console.WriteLine("Você entrou na área do suporte");
                }
                else if(opcao == 3)
                {
                    Console.WriteLine("Você fechou o programa!\n\n");
                    break;
                }
            }
        }
    }

    
}
