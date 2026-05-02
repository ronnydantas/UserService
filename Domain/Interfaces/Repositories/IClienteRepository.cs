using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IClienteRepository : IBaseRepository<ClienteCompleto>
{
    Task<ClienteCompleto?> ConsultarPorId(int id);
    Task<ClienteCompleto?> ConsultarPorNome(string nome);
    Task<IEnumerable<ClienteCompleto>> ConsultarTodos();
    Task<ClienteCompleto> PreCadastro(ClienteConsumer clienteConsumer);
}

