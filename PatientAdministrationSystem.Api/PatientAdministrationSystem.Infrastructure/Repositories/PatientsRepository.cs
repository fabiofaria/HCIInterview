using Microsoft.EntityFrameworkCore;
using PatientAdministrationSystem.Application.Entities;
using PatientAdministrationSystem.Application.Repositories.Interfaces;

namespace PatientAdministrationSystem.Infrastructure.Repositories;

public class PatientsRepository : IPatientsRepository
{
    private readonly HciDataContext _context;

    public PatientsRepository(HciDataContext context)
    {
        _context = context;
    }

    public async Task<IList<PatientEntity>> RetrievePatientAsync(string email, CancellationToken cancellationToken)
    {
        var results = await _context.Patients
            .Include(t=> t.PatientHospitals)!
                .ThenInclude(t=> t.Hospital)
            .Include(t=> t.PatientHospitals)!
                .ThenInclude(t=> t.Visit)
            .Where(t => t.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase))
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return results;
    }
}