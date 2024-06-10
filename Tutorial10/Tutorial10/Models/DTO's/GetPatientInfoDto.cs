namespace Tutorial10.Models.DTO_s;

public class GetPatientInfoDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public ICollection<GetPrescriptionDTO> Prescriptions { get; set; } = null!;
}

public class GetPrescriptionDTO
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public ICollection<PrescriptionMedicamentDTO> Medicaments { get; set; } = null!;
    public DoctorInfoDTO Doctor { get; set; } = null!;
}

public class PrescriptionMedicamentDTO
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public int? Dose { get; set; }
    public string Description { get; set; }
}

public class DoctorInfoDTO
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; } 
}