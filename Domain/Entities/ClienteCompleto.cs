using System.Text.Json.Serialization;

namespace Domain.Entities;

public record class ClienteCompleto
{
    [JsonIgnore]
    public string Id { get; set; } = string.Empty;
    [JsonIgnore]
    public string Name { get; set; } = string.Empty;
    [JsonIgnore]
    public string FullName { get; set; } = string.Empty;
    [JsonIgnore]
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

    public ClienteCompleto(string phone, DateOnly birthDate, DateTime registrationDate, bool allergy, string observation, string gender)
    {
        Phone = phone;
        BirthDate = birthDate;
        RegistrationDate = registrationDate;
        Allergy = allergy;
        Observation = observation;
        Gender = gender;
    }
}
