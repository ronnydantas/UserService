namespace Domain.Entities;

public record class ClienteCompleto
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

    public ClienteCompleto()
    {
    }

}
