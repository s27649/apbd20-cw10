using Microsoft.EntityFrameworkCore;
using Tutorial10.Data;
using Tutorial10.Models;

namespace Tutorial10.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly PrescriptionContext _context;

    public PatientRepository(PrescriptionContext context)
    {
        _context = context;
    }

    public async Task<Patient?> GetPatient(int idPatient)
    {
        return await _context.Patients
            .Include(p => p.Prescriptions)
            .ThenInclude(p => p.Doctor)
            .Include(p => p.Prescriptions)
            .ThenInclude(p => p.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .FirstOrDefaultAsync(p => p.IdPatient == idPatient);

    }
}