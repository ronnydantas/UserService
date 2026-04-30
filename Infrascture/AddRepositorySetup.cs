using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrascture.Contexts;
using Infrascture.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrascture;

public static class AddRepositorySetup
{
    public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ClientContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("PostgresConnection"));
        });
        services.AddScoped<IBaseRepository<ClienteCompleto>, BaseRepository<ClienteCompleto>>();

        return services;
    }
}
