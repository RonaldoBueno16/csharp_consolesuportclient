using System;
using System.Collections.Generic;

namespace Suporte_ao_cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            string string_digitada;
            int numeracao_chamados = 1;
            Cliente usuario = null;
            List<Cliente> todos_usuarios = new List<Cliente>();

            while(true)
            {
                Console.WriteLine("Usuários cadastrados: " + todos_usuarios.Count);

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
                    string nome_cliente;

                    DigitarNome:
                    Console.Write("\nDigite o nome do usuário: ");
                    string_digitada = Console.ReadLine();

                    usuario = GetClientName(string_digitada);
                    if(usuario == null)
                    {
                        nome_cliente = string_digitada;

                        usuario = new Cliente(nome_cliente);
                        Console.WriteLine("Você criou o usuário:[" + nome_cliente + "] com sucesso!");
                        todos_usuarios.Add(usuario);
                    }

                    while(true)
                    {
                        Console.WriteLine("\n\n=====================================");
                        Console.WriteLine("====[Selecione a opção desejada]=====");
                        Console.WriteLine("=====================================");
                        Console.WriteLine("1 - Meus chamados");
                        Console.WriteLine("2 - Registrar ticket");
                        Console.WriteLine("3 - Voltar");

                        VoltarUser:
                        Console.Write("\nOpção desejada: ");
                        string_digitada = Console.ReadLine();
                        if (string_digitada == "" || (string_digitada != "1" && string_digitada != "2" && string_digitada != "3"))
                        {
                            Console.WriteLine("Você precisa digitar uma opção válida!");
                            goto VoltarUser;
                        }
                        opcao = int.Parse(string_digitada);


                        if(opcao == 1)
                        {
                            Ticket ticket = usuario.getTicket();
                            if (ticket == null)
                                Console.WriteLine("Você não tem nenhum chamado em aberto");
                            else
                            {
                                Console.WriteLine("\nInformações do meu chamado:");
                                Console.WriteLine("\tSTATUS: " + (ticket.chamado_aberto ? ("EM ANDAMENTO") : ("FINALIZADO")) );
                                Console.WriteLine("\tNúmero do ticket: " + ticket.numero_chamado);
                                Console.WriteLine("\tTitulo: " + ticket.titulo);
                                Console.WriteLine("\tDescrição: " + ticket.descricao);
                                if (!ticket.chamado_aberto)
                                    Console.WriteLine("\tResposta do suporte: " + ticket.resposta);
                                
                            }
                        }
                        else if(opcao == 2)
                        {
                            Console.WriteLine("\n=====[Abrindo chamado]=====");
                            Console.Write("Digite o titulo do ticket: ");
                            string titulo_chamado = Console.ReadLine();
                            Console.Write("Digite o problema ocorrido: ");
                            string descricao = Console.ReadLine();

                            usuario.AbrirChamado(descricao, titulo_chamado, numeracao_chamados);

                            Console.WriteLine("\nInformações do ticket:");
                            Console.WriteLine("\tCliente: " + usuario.getName());
                            Console.WriteLine("\tNº do ticket: " + numeracao_chamados);
                            Console.WriteLine("\tTitulo: " + titulo_chamado);
                            Console.WriteLine("\tDescrição: " + descricao);

                            numeracao_chamados++;
                        }
                        else if(opcao == 3)
                        {
                            Console.Clear();
                            break;
                        }
                    }
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
                    
                    if(login != "admin" || senha != "admin")
                    {
                        string tentar_novamente;
                        Console.Write("\nVocê digitou um usuário inválido, deseja tentar novamente? [Y/N] ");
                        tentar_novamente = Console.ReadLine();

                        if (tentar_novamente == "Y" || tentar_novamente == "y")
                            goto TentarNovamente;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Você se conectou na área de suporte!");

                        while(true)
                        {
                            Console.WriteLine("\n\n=====================================");
                            Console.WriteLine("====[Selecione a opção desejada]=====");
                            Console.WriteLine("=====================================");
                            Console.WriteLine("1 - Listar chamados");
                            Console.WriteLine("2 - Voltar");
                            VoltarSuporte:
                            Console.Write("\nOpção desejada: ");
                            string_digitada = Console.ReadLine();

                            if (string_digitada == "" || (string_digitada != "1" && string_digitada != "2"))
                            {
                                Console.WriteLine("Você precisa digitar uma opção válida!");
                                goto VoltarSuporte;
                            }
                            opcao = int.Parse(string_digitada);

                            if(opcao == 1)
                            {
                                Console.WriteLine("Lista de chamados:");
                                int count = 0;
                                foreach (Cliente client in todos_usuarios)
                                {
                                    if (client.getTicket() == null)
                                        continue;
                                    else
                                    {
                                        Ticket ticket = client.getTicket();

                                        if(ticket.chamado_aberto)
                                        {
                                            Console.WriteLine("Nº do chamado:["+ ticket.numero_chamado +"] - Cliente:["+ client.getName() +"]");
                                            count++;
                                        }
                                    }
                                }
                                if(count == 0)
                                    Console.WriteLine("Não tem nenhum chamado em aberto!");
                                else
                                {
                                    VoltarTicket:
                                    Console.Write("\nDigite o codigo do chamado que você deseja atender: ");

                                    string_digitada = Console.ReadLine();
                                    int ticketid;
                                    bool isNumber = Int32.TryParse(string_digitada, out ticketid);
                                    if (!isNumber)
                                    {
                                        Console.WriteLine("O número do ticket é composto por apenas números!");
                                        goto VoltarTicket;
                                    }

                                    Ticket ticket = GetTicketToID(ticketid);
                                    if(ticket == null)
                                    {
                                        ReturnYNInvalid:
                                        Console.WriteLine("Não foi encontrado esse número de ticket em nosso banco de dados\nDeseja tentar novamente? [Y/N]");
                                        string_digitada = Console.ReadLine().ToUpper();

                                        if (string_digitada == "Y")
                                            goto VoltarTicket;
                                        else if(string_digitada != "N")
                                        {
                                            Console.WriteLine("Você digitou uma opção inválida!");
                                            goto ReturnYNInvalid;
                                        }
                                    }
                                    else
                                    {
                                        Cliente ownerTicket = ticket.getUserTicket();

                                        Console.WriteLine("\nExibindo ticket Nº["+ticket.numero_chamado+"]");
                                        Console.WriteLine("Usuário: " + ownerTicket.getName());
                                        Console.WriteLine("Assunto: " + ticket.titulo);
                                        Console.WriteLine("Descrição: " + ticket.descricao);

                                        Console.Write("\nDigite a sua resposta para esse chamado: ");
                                        string_digitada = Console.ReadLine();

                                        ticket.ResponderTicket(string_digitada);

                                        Console.WriteLine("Você atendeu o chamado de Nº[" + ticket.numero_chamado + "] do usuário:[" + ownerTicket.getName() + "]");
                                    }
                                }
                            }
                            else if(opcao == 2)
                            {
                                Console.Clear();
                                break;
                            }
                        }


                    }
                }
                else if(opcao == 3)
                {
                    Console.WriteLine("Você fechou o programa!\n\n");
                    break;
                }
            }

            Cliente GetClientName(string name)
            {
                foreach(Cliente client in todos_usuarios)
                {
                    if (client.getName() == name)
                        return client;
                }
                return null;
            }

            Ticket GetTicketToID(int id)
            {
                Ticket ticket_index;
                foreach(Cliente client in todos_usuarios)
                {
                    ticket_index = client.getTicket();
                    if (ticket_index == null)
                        return null;
                    else
                        return ticket_index;
                }
                return null;
            }
        }

    }

    class Cliente
    {
        private string nome;
        private Ticket chamado;

        public string getName()
        {
            return this.nome;
        }

        public Cliente(string _nome)
        {
            this.nome = _nome;
        }

        public void AbrirChamado(string descricao, string titulo, int number)
        {
            chamado = new Ticket(descricao, titulo, number, this);
        }

        public bool CancelarChamado()
        {
            if (this.chamado == null)
                return false;
            else
            {
                this.chamado = null;
                return true; 
            }
        }

        public Ticket getTicket()
        {
            return this.chamado;
        }
    }

    class Ticket
    {
        public bool chamado_aberto = false;
        public int numero_chamado;
        public string descricao;
        public string titulo;
        public string resposta;
        private Cliente client;

        public Ticket(string descricaoTicket, string tituloTicket, int numberTicket, Cliente clientTicket)
        {
            this.chamado_aberto = true;
            this.numero_chamado = numberTicket;
            this.descricao = descricaoTicket;
            this.titulo = tituloTicket;
            this.client = clientTicket;
        }

        public void ResponderTicket(string respostaTicket)
        {
            this.resposta = respostaTicket;
            this.chamado_aberto = false;
        }

        public Cliente getUserTicket()
        {
            return this.client;
        }
    }
}

