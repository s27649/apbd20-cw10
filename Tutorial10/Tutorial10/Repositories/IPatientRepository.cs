using Tutorial10.Models;

namespace Tutorial10.Repositories;

public interface IPatientRepository
{
    public Task<Patient?> GetPatient(int idPatient);
    
}