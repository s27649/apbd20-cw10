namespace Tutorial10.Models.DTO_s;

public class NewPrescriptionDto
{
    public PatientDTO Patient { get; set; } = null!;
    public int IdDoctor { get; set; }
    public ICollection<PrescriptionMedicamentsDTO> Medicaments { get; set; } = null!;
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    
}

public class PatientDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
}

public class PrescriptionMedicamentsDTO
{
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    public string Description { get; set; }
}

