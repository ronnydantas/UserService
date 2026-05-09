using Domain.UseCases.CreatePerson.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers.v1;

/// <summary>
/// Controlador responsável por gerenciar operações relacionadas a clientes na API v1.
/// </summary>s
[ApiController]
[Route("api/v1/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Inicializa uma nova instância de <see cref="PersonController"/>.
    /// </summary>
    /// <param name="mediator">Instância do MediatR para envio de comandos e consultas.</param>
    public PersonController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Atualiza um cliente existente.
    /// </summary>
    /// <param name="id">Id do cliente.</param>
    /// <param name="command">Comando contendo os dados do cliente a ser atualizado.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação assíncrona.</param>
    /// <returns>Retorna 200 (OK) se atualizado com sucesso ou 400 (Bad Request) em caso de erro.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCliente(string id, [FromBody] UpdatePersonCommand command, CancellationToken cancellationToken)
    {
        command.Cliente.Id = id;

        var result = await _mediator.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}