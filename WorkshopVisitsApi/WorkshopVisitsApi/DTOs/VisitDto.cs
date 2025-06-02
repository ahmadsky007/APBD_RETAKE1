namespace WorkshopVisitsApi.DTOs;

public class VisitDto
{
    public DateTime Date { get; set; }
    public ClientDto Client { get; set; } = null!;
    public MechanicDto Mechanic { get; set; } = null!;
    public List<VisitServiceDto> VisitServices { get; set; } = new();
}