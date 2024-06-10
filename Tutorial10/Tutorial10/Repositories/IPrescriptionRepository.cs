using Tutorial10.Models;
using Tutorial10.Models.DTO_s;

namespace Tutorial10.Repositories;

public interface IPrescriptionRepository
{
    public Task<int> AddPrescription(Prescription prescription);
    public Task<int> AddPatient(PatientDTO patient);
    public Task<int> AddPrescriptionMedicament(PrescriptionMedicament prescriptionMedicament);
    public Task<bool> DoesMedicamentExist(ICollection<PrescriptionMedicamentsDTO> medicament);
}