using WorkshopVisitsApi.DTOs;
using WorkshopVisitsApi.Repositories.Interfaces;
using WorkshopVisitsApi.Services.Interfaces;

namespace WorkshopVisitsApi.Services.Implementations;

public class VisitsService : IVisitsService
{
    private readonly IVisitsRepository _repository;

    public VisitsService(IVisitsRepository repository)
    {
        _repository = repository;
    }

    public async Task<VisitDto?> GetVisitByIdAsync(int id)
    {
        var visit = await _repository.GetVisitWithDetailsAsync(id);
        if (visit == null) return null;

        return new VisitDto
        {
            Date = visit.Date,
            Client = new ClientDto
            {
                FirstName = visit.Client.FirstName,
                LastName = visit.Client.LastName,
                DateOfBirth = visit.Client.DateOfBirth
            },
            Mechanic = new MechanicDto
            {
                MechanicId = visit.Mechanic.MechanicId,
                LicenceNumber = visit.Mechanic.LicenceNumber
            },
            VisitServices = visit.VisitServices
                .Select(vs => new VisitServiceDto
                {
                    Name = vs.Service.Name,
                    ServiceFee = vs.ServiceFee
                }).ToList()
        };
    }
}