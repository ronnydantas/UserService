O UserService é responsável por:

✅ Consumir mensagens do RabbitMQ
✅ Processar eventos de criação de usuário
✅ Realizar pré-cadastro automático de clientes
✅ Persistir dados no PostgreSQL
✅ Desacoplar regras de negócio da API de autenticação

🛠 Tecnologias utilizadas
ASP.NET Core / .NET 9
C#
Entity Framework Core
PostgreSQL
RabbitMQ
Docker
Swagger
BackgroundService
Dependency Injection
🧠 Arquitetura
Identity API → RabbitMQ → UserService
🐇 Integração com RabbitMQ

A API consome mensagens publicadas pela Identity API.

Exchange utilizada
user.exchange
Queue utilizada
user.queue
📦 Estrutura da mensagem consumida
{
  "id": "guid",
  "name": "rafael",
  "fullName": "Rafael Oliveira",
  "email": "rafael@email.com"
}
⚙️ BackgroundService

O consumo de mensagens é realizado utilizando BackgroundService, permitindo que o serviço fique escutando eventos continuamente em segundo plano.

🗄 Banco de dados

A API utiliza PostgreSQL para persistência dos dados dos clientes.

⚙️ Configuração do appsettings.json
RabbitMQ
"RabbitMQ": {
  "Host": "localhost",
  "Port": 5672,
  "Username": "guest",
  "Password": "guest"
}
PostgreSQL
"ConnectionStrings": {
  "PostgresConnection": "Host=localhost;Port=5432;Database=cliente_db;Username=postgres;Password=root"
}
🐳 Executando RabbitMQ com Docker
docker run -d --name rabbitmq \
-p 5672:5672 \
-p 15672:15672 \
rabbitmq:3-management
🌐 Painel RabbitMQ
http://localhost:15672
Credenciais padrão
Usuário: guest
Senha: guest
▶️ Como executar o projeto
1. Clonar o repositório
git clone <url-do-repositorio>
2. Restaurar pacotes
dotnet restore
3. Executar migrations
dotnet ef database update
4. Executar RabbitMQ
docker run -d --name rabbitmq \
-p 5672:5672 \
-p 15672:15672 \
rabbitmq:3-management
5. Executar a aplicação
dotnet run
📘 Swagger

A documentação Swagger está habilitada para testes da API.

Exemplo:

https://localhost:{porta}/swagger
📂 Estrutura do projeto
/Domain
    - Entidades
    - Interfaces
    - Regras de negócio

/Infrascture
    - Repositórios
    - DbContext
    - Configurações EF Core

/UserService
    - Controllers
    - Swagger
    - RabbitMQ Consumer
    - Configurações da aplicação
🔥 Funcionalidades implementadas

✅ Consumo de mensagens RabbitMQ
✅ Pré-cadastro automático de clientes
✅ Persistência em PostgreSQL
✅ Comunicação assíncrona
✅ Worker em BackgroundService
✅ Swagger configurado
✅ Integração entre microsserviços