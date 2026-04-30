using Domain.Entities;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

public class RabbitMqConsumer
{
    private readonly RabbitMqSettings _settings;

    public RabbitMqConsumer(IOptions<RabbitMqSettings> settings)
    {
        _settings = settings.Value;
    }

    public void Start()
    {
        var factory = new ConnectionFactory()
        {
            HostName = _settings.Host,
            Port = _settings.Port,
            UserName = _settings.Username,
            Password = _settings.Password
        };

        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

    }
}