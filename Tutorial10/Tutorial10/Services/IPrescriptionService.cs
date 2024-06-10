using Tutorial10.Models;
using Tutorial10.Models.DTO_s;

namespace Tutorial10.Services;

public interface IPrescriptionService
{
    public Task<int> AddPrescription(NewPrescriptionDto prescription);
}