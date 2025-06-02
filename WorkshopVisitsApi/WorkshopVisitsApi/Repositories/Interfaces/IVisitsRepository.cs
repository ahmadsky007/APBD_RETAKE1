using WorkshopVisitsApi.Models;

namespace WorkshopVisitsApi.Repositories.Interfaces;

public interface IVisitsRepository
{
    Task<Visit?> GetVisitWithDetailsAsync(int id);
}