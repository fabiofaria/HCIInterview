using PatientAdministrationSystem.Application.Dtos;

namespace PatientAdministrationSystem.Application.Interfaces;

public interface IPatientsService
{
    Task<IList<PatientVisitInformation>> FindPatientVisitsByEmailAsync(string email, CancellationToken cancellationToken);
}