using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PatientAdministrationSystem.Application.Dtos;
using PatientAdministrationSystem.Application.Interfaces;

namespace PatientAdministrationSystem.API.Controllers;

[Route("api/patients")]
[ApiExplorerSettings(GroupName = "Patients")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IPatientsService _patientsService;

    public PatientsController(IPatientsService patientsService)
    {
        _patientsService = patientsService;
    }

    [HttpGet("visit-information")]
    [ProducesResponseType<List<PatientVisitInformation>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetVisitInformation([FromQuery][EmailAddress] string email, CancellationToken cancellationToken)
    {
        var results = await _patientsService.FindPatientVisitsByEmailAsync(email, cancellationToken);
        return Ok(results);
    }
}

