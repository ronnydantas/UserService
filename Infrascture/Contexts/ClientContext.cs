using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrascture.Contexts;

public class ClientContext : DbContext
{
    public ClientContext(DbContextOptions<ClientContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<ClienteCompleto> Clientes { get; set; }
}
