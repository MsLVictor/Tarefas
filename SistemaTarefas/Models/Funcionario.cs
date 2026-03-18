using SistemaTarefas.Enums;

namespace SistemaTarefas.Models;

public class Funcionario : Colaborador
{
    public Funcionario(string nome, string email, PerfilAcessoEnum perfilAcesso) : base(nome, email, perfilAcesso)
    {
    }
}
