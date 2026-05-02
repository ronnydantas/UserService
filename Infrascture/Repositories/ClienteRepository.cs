using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrascture.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrascture.Repositories;

public class ClienteRepository : BaseRepository<ClienteCompleto>, IClienteRepository
{
    public ClienteRepository(ClientContext context) : base(context)
    {
    }
    public async Task<ClienteCompleto?> ConsultarPorId(int id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task<ClienteCompleto?> ConsultarPorNome(string nome)
    {
        return await _context.Clientes
            .FirstOrDefaultAsync(c => c.Name == nome);
    }
    public async Task<IEnumerable<ClienteCompleto>> ConsultarTodos()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<ClienteCompleto> PreCadastro(ClienteConsumer clienteConsumer)
    {

        var cliente = new ClienteCompleto
        {
            Id = clienteConsumer.Id,
            Name = clienteConsumer.UserName,
            FullName = clienteConsumer.FullName,
            Email = clienteConsumer.Email,
        };
        
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();

        return cliente;

    }
}
