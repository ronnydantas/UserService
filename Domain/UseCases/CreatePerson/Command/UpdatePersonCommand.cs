using Domain.Entities;
using Domain.Shareds;
using Domain.ViewModels;
using MediatR;

namespace Domain.UseCases.CreatePerson.Command;

public record class UpdatePersonCommand(ClienteCompleto Cliente) : IRequest<Response<PersonViewModel>>;