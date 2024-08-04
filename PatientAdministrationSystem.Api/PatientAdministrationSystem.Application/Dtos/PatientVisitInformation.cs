namespace PatientAdministrationSystem.Application.Dtos;

public record PatientVisitInformation(
    Guid PatientId, 
    string PatientName,
    Guid HospitalId,
    string HospitalName,
    Guid VisitId,
    DateTime VisitDate);