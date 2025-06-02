using Microsoft.EntityFrameworkCore;
using WorkshopVisitsApi.Data;
using WorkshopVisitsApi.Models;
using WorkshopVisitsApi.Repositories.Interfaces;

namespace WorkshopVisitsApi.Repositories.Implementations;

public class VisitsRepository : IVisitsRepository
{
    private readonly WorkshopVisitsContext _context;

    public VisitsRepository(WorkshopVisitsContext context)
    {
        _context = context;
    }

    public async Task<Visit?> GetVisitWithDetailsAsync(int id)
    {
        return await _context.Visits
            .Include(v => v.Client)
            .Include(v => v.Mechanic)
            .Include(v => v.VisitServices)
            .ThenInclude(vs => vs.Service)
            .FirstOrDefaultAsync(v => v.VisitId == id);
    }
}