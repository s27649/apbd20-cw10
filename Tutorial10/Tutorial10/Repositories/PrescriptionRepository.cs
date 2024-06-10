using Microsoft.EntityFrameworkCore;
using Tutorial10.Data;
using Tutorial10.Models;
using Tutorial10.Models.DTO_s;

namespace Tutorial10.Repositories;

public class PrescriptionRepository: IPrescriptionRepository
{
    private readonly PrescriptionContext _context;

    public PrescriptionRepository(PrescriptionContext context)
    {
        _context = context;
    }
    public async Task<int> AddPrescription(Prescription prescription)
    {
        await _context.Prescriptions.AddAsync(prescription);
        await _context.SaveChangesAsync();
        return prescription.IdPrescription;
    }
    
    public async Task<int> AddPatient(PatientDTO patient)
    {
        await _context.Patients.AddAsync(new Patient()
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            BirthDate = patient.BirthDate
        });
        await _context.SaveChangesAsync();
        return 1;
    }

    public async Task<int> AddPrescriptionMedicament(PrescriptionMedicament prescriptionMedicament)
    {
        await _context.PrescriptionMedicaments.AddAsync(prescriptionMedicament);
        await _context.SaveChangesAsync();
        return 1;
    }

    public async Task<bool> DoesMedicamentExist(ICollection<PrescriptionMedicamentsDTO> medicament)
    {
        var medicamets = medicament.Select(med => med.IdMedicament).ToList();

        var exist = await _context.Medicaments
            .Where(med => medicamets.Contains(med.IdMedicament))
            .Select(med => med.IdMedicament)
            .ToListAsync();
        var allMed = medicamets.All(m => exist.Contains(m));
        return allMed;
    }
}