﻿using System;

namespace Suporte_ao_cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            

            int opcao;
            string string_digitada;

            while(true)
            {
                Console.WriteLine("\n\n=====================================");
                Console.WriteLine("====[Selecione a opção desejada]=====");
                Console.WriteLine("=====================================");
                Console.WriteLine("1 - Entrar como cliente (ABRIR CHAMADO)");
                Console.WriteLine("2 - Entrar como suporte (ATENDER CHAMADO)");
                Console.WriteLine("3 - Encerrar");

                Voltar:
                Console.Write("\nOpção desejada: ");
                string_digitada = Console.ReadLine();
                if (string_digitada == "" || (string_digitada != "1" && string_digitada != "2" && string_digitada != "3"))
                {
                    Console.WriteLine("Você precisa digitar uma opção válida!");
                    goto Voltar;
                }
                opcao = int.Parse(string_digitada);

                if(opcao == 1)
                {
                    Console.Write("Digite o seu nome: ");
                    string nome_cliente = Console.ReadLine();
                    VoltarIdade:
                    Console.Write("Digite a sua idade: ");
                    string_digitada = Console.ReadLine();

                    int idade;
                    bool isNumber = Int32.TryParse(string_digitada, out idade);
                    if(!isNumber)
                    {
                        Console.WriteLine("Você digitou um valor inválido");
                        goto VoltarIdade;
                    }
                    
                    Cliente usuario = new Cliente();
                    usuario.RegistrarCliente(nome_cliente, idade);

                    Console.Write("Digite o titulo do ticket: ");
                    string titulo_chamado = Console.ReadLine();
                    Console.Write("Digite o problema ocorrido: ");
                    string problema = Console.ReadLine();

                    usuario.AbrirChamado(titulo_chamado, problema);

                    Console.WriteLine("\nVocê abriu o ticket:[" + titulo_chamado+"] com o assunto:["+ problema + "]\n\n");
                }
                else if(opcao == 2)
                {
                    string login, senha;
                    TentarNovamente:
                    Console.WriteLine("\n===[CREDENCIAIS]===");
                    Console.Write("Digite o usuário: ");
                    login = Console.ReadLine();

                    Console.Write("Digite a senha: ");
                    senha = Console.ReadLine();

                    Console.WriteLine(login + senha);
                    
                    if(login != "admin" || senha != "admin")
                    {
                        string tentar_novamente;
                        ErrouLetra:
                        Console.Write("\nVocê digitou um usuário inválido, deseja tentar novamente? [Y/N] ");
                        tentar_novamente = Console.ReadLine();

                        if (tentar_novamente == "Y" || tentar_novamente == "y")
                            goto TentarNovamente;
                    }
                }
                else if(opcao == 3)
                {
                    Console.WriteLine("Você fechou o programa!\n\n");
                    break;
                }
            }
        }
    }

    class Cliente
    {
        private string nome;
        private int idade;

        private string[] InfoChamado = new string[2] {"", ""};

        public void RegistrarCliente(string _nome, int _idade)
        {
            this.nome = _nome;
            this.idade = _idade;
        }

        public void AbrirChamado(string assunto, string problema)
        {

        }
    }

     
}
