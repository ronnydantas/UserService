using Domain.Entities;

namespace Domain.ViewModels;

public record class PersonViewModel
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool Allergy { get; set; }
    public string Observation { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;

    public PersonViewModel(ClienteCompleto clienteCompleto)
    {
        Id = clienteCompleto.Id;
        Name = clienteCompleto.Name;
        FullName = clienteCompleto.FullName;
        Email = clienteCompleto.Email;
        Phone = clienteCompleto.Phone;
        BirthDate = clienteCompleto.BirthDate;
        RegistrationDate = clienteCompleto.RegistrationDate;
        Allergy = clienteCompleto.Allergy;
        Observation = clienteCompleto.Observation;
        Gender = clienteCompleto.Gender;
    }
}
