using PatientAdministrationSystem.Application.Dtos;
using PatientAdministrationSystem.Application.Entities;
using PatientAdministrationSystem.Application.Interfaces;
using PatientAdministrationSystem.Application.Repositories.Interfaces;

namespace PatientAdministrationSystem.Application.Services;

public class PatientsService : IPatientsService
{
    private readonly IPatientsRepository _repository;

    public PatientsService(IPatientsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IList<PatientVisitInformation>> FindPatientVisitsByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var patients = await _repository.RetrievePatientAsync(email, cancellationToken);
        var results = new List<PatientVisitInformation>();
        if (patients.Count == 0)
        {
            return results;
        }

        foreach (var patient in patients)
        {
            if (patient.PatientHospitals.Count == 0)
            {
                continue;
            }

            results.AddRange(GeneratePatientVisitInformation(patient));
        }

        return results;
    }

    private static IEnumerable<PatientVisitInformation> GeneratePatientVisitInformation(PatientEntity patient)
        => patient.PatientHospitals.Select(info => new PatientVisitInformation(
            info.PatientId,
            $"{patient.FirstName} {patient.LastName}",
            info.HospitalId,
            info.Hospital.Name,
            info.VisitId,
            info.Visit.Date));
}