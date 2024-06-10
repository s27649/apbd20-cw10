using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tutorial10.Models.DTO_s;
using Tutorial10.Services;

namespace Tutorial10.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientPrescriptionController:ControllerBase
{
    private readonly IPatientService _patientService;
    private readonly IPrescriptionService _prescriptionService;

    public PatientPrescriptionController(IPatientService patientService, IPrescriptionService prescriptionService)
    {
        _patientService = patientService;
        _prescriptionService = prescriptionService;
    }

    [HttpGet("{idPatient}")]
    public async Task<IActionResult> GetPatient(int idPatient)
    {
          var patient = await _patientService.GetPatient(idPatient);
          return Ok(patient);
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription(NewPrescriptionDto prescriptionDto)
    {
        try
        {
            var prescription = await _prescriptionService.AddPrescription(prescriptionDto);
            return Ok(prescription);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
}