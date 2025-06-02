using WorkshopVisitsApi.DTOs;

namespace WorkshopVisitsApi.Services.Interfaces;

public interface IVisitsService
{
    Task<VisitDto?> GetVisitByIdAsync(int id);
}