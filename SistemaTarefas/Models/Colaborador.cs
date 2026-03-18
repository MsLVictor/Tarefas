namespace SistemaTarefas.Models;

using SistemaTarefas.Enums;

public abstract class Colaborador
{
    public Colaborador(string nome, string email, PerfilAcessoEnum perfilAcesso)
    {
        ValidarNome(nome);
        ValidarEmail(email);
        PerfilAcesso = perfilAcesso;
    }

    public string Nome { get; protected set; }
    public string Email { get; protected set; }
    public PerfilAcessoEnum PerfilAcesso { get; protected set; }

    private void ValidarNome(string nome)
    {
        if(string.IsNullOrEmpty(nome))
        {
            Console.WriteLine("Nome inválido");
            return;
        }

        Nome = nome;
    }

    private void ValidarEmail(string email)
    {
        if(string.IsNullOrEmpty(email))
        {
            Console.WriteLine("Email inválido");
            return;
        }

        Email = email;
    }
}
