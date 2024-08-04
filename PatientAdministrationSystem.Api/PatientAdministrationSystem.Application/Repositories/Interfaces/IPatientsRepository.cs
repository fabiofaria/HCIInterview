using PatientAdministrationSystem.Application.Entities;

namespace PatientAdministrationSystem.Application.Repositories.Interfaces;

public interface IPatientsRepository
{
    Task<IList<PatientEntity>> RetrievePatientAsync(string email, CancellationToken cancellationToken);
}