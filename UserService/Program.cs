using Domain.Entities;
using UserService.Extensions;
using UserService.Extensions.SwaggerConfigurations;
using Infrascture;

/// <summary>
/// Classe principal do aplicativo Cliente API.
/// </summary>
public class Program
{
    /// <summary>
    /// Ponto de entrada principal do aplicativo.
    /// </summary>
    /// <param name="args">Argumentos de linha de comando.</param>
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configuração de serviços
        builder.Services
            .AddSwaggerConfig(builder.Configuration)
            .AddControllers();

        builder.Services.AddCustomCors();

        builder.Services.AddRepository(builder.Configuration);

        builder.Services.Configure<RabbitMqSettings>(
            builder.Configuration.GetSection("RabbitMQ"));

        builder.Services.AddHostedService<RabbitMqBackgroundService>();

        var app = builder.Build();

        app.UsePathBase("/user-service");

        app.UseCustomCors();

        app.UseRouting();

        // Swagger
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/user-service/swagger/v1/swagger.json", "UserService API V1");
            options.RoutePrefix = string.Empty;
        });

        app.MapControllers();

        await app.RunAsync();
    }
}