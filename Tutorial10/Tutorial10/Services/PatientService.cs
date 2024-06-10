using Tutorial10.Models.DTO_s;
using Tutorial10.Repositories;

namespace Tutorial10.Services;

public class PatientService:IPatientService
{
    private readonly IPatientRepository _repository;

    public PatientService(IPatientRepository repository)
    {
        _repository = repository;
    }


    public async Task<GetPatientInfoDto> GetPatient(int idPatient)
    {
        var patient = await _repository.GetPatient(idPatient);
        if (patient == null)
        {
            throw new Exception("No patient with this id");
        }

        var prescriptions = patient.Prescriptions.Select(pr => new GetPrescriptionDTO()
        {
            IdPrescription = pr.IdPrescription,
            Date = pr.Date,
            DueDate = pr.DueDate,
            Doctor = new DoctorInfoDTO()
            {
                IdDoctor = pr.Doctor.IdDoctor,
                FirstName = pr.Doctor.FirstName
            }
        }).ToList();

        foreach (var prescription in prescriptions)
        {
            var prescriptionPatient = patient.Prescriptions.First(p => p.IdPrescription == prescription.IdPrescription);
            var medicaments = prescriptionPatient.PrescriptionMedicaments.Select(pm =>
                new PrescriptionMedicamentDTO()
                {
                    IdMedicament = pm.IdMedicament,
                    Name = pm.Medicament.Name,
                    Description = pm.Medicament.Description,
                    Dose = pm.Dose
                }).ToList();
            prescription.Medicaments = medicaments;
        }

        var patientInfo = new GetPatientInfoDto()
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            BirthDate = patient.BirthDate,
            Prescriptions = prescriptions
        };
        return patientInfo;
    }
}