# csharp_consolesuportclient
Projeto da matéria de C# faculdade UCL.

O sistema que vamos criar consiste em uma chamada de um suporte do  site para resolução de um problema especifico . Será criado 2 classes, uma para o cliente e outra para o suporte, com os seguintes métodos:  

Metodos cliente:
- abrirChamado(string title, string description, priority) - Abre o chamado para o suporte (VAI GERAR UM ID PARA O CHAMADO)
- listarMeusChamados() - Lista dos os chamados do cliente que executar

Metodos suporte:
- listarChamados() - Lista todos os chamados de todos os clientes
- ExibirChamado(int id) - Lista o chamado que ele selecionou (PELO ID)
- ResponderChamado(int id, string resposta) - Responde o chamado e fecha-o automaticamente
;
