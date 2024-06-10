using Tutorial10.Models;
using Tutorial10.Models.DTO_s;
using Tutorial10.Repositories;

namespace Tutorial10.Services;

public class PrescriptionService:IPrescriptionService
{
    
    private readonly IPrescriptionRepository _repository;
    private readonly IPatientRepository _patientRepository;
    

    public PrescriptionService(IPrescriptionRepository repository, IPatientRepository patientRepository)
    {
        _repository = repository;
        _patientRepository = patientRepository;
    }
    public async Task<int> AddPrescription(NewPrescriptionDto prescription)
    {
        await DoesMedicamentExist(prescription.Medicaments);
        DueDateIsBigger(prescription.DueDate,prescription.Date);
        LimitMedicaments(prescription.Medicaments, 10);
        var patient = _patientRepository.GetPatient(prescription.Patient.IdPatient);
        if (patient == null)
        {
            var newPatient = _repository.AddPatient(prescription.Patient);
        }

        var newPrescription = await _repository.AddPrescription(new Prescription()
        {
            IdPatient = prescription.Patient.IdPatient,
            IdDoctor = prescription.IdDoctor,
            Date = prescription.Date,
            DueDate = prescription.DueDate
        });

        foreach (var medicament in prescription.Medicaments)
        {
            var med = new PrescriptionMedicament()
            {
                IdMedicament = medicament.IdMedicament,
                IdPrescription = newPrescription,
                Dose = medicament.Dose,
                Details = medicament.Description
            };
            await _repository.AddPrescriptionMedicament(med);

        }

        return 1;
    }

    public async Task<bool> DoesMedicamentExist(ICollection<PrescriptionMedicamentsDTO> medicament)
    {
        var exist = await _repository.DoesMedicamentExist(medicament);
        if (!exist) { throw new Exception("Doesn't exist"); }
        return true;
    }

    public bool LimitMedicaments(ICollection<PrescriptionMedicamentsDTO> medicaments, int limit)
    {
        var medLim = medicaments.Count > limit;
        if (medLim)
        {
            throw new Exception("Count of medicamets is bigger");
        }

        return false;
    }

    public bool DueDateIsBigger(DateTime dueDate, DateTime date)
    {
        if (dueDate >= date)
        {
            throw new Exception("DueDate is bigger then Date");
        }

        return true;
    }
}