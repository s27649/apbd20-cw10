using Tutorial10.Models.DTO_s;

namespace Tutorial10.Services;

public interface IPatientService
{
    public Task<GetPatientInfoDto> GetPatient(int idPatient);
}