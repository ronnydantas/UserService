using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Shareds;
using Domain.UseCases.CreatePerson.Command;
using Domain.ViewModels;
using MediatR;

namespace Domain.UseCases.CreatePerson;

public class AtualizarClienteUseCase(IClienteRepository clienteRepository) : IRequestHandler<UpdatePersonCommand, Response<PersonViewModel>>
{
    public async Task<Response<PersonViewModel>> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var clienteExistente = await clienteRepository.ConsultarPorId(request.Cliente.Id);

        if (clienteExistente is null)
            return new Response<PersonViewModel>("Cliente não encontrado");

        clienteExistente.Phone = request.Cliente.Phone;
        clienteExistente.BirthDate = request.Cliente.BirthDate;
        clienteExistente.RegistrationDate = request.Cliente.RegistrationDate;
        clienteExistente.Allergy = request.Cliente.Allergy;
        clienteExistente.Observation = request.Cliente.Observation;
        clienteExistente.Gender = request.Cliente.Gender;

        await clienteRepository.UpdateAsync(clienteExistente);

        var clienteViewModel = new PersonViewModel(clienteExistente);

        return new(clienteViewModel);
    }
}