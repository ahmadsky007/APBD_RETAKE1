namespace WorkshopVisitsApi.Models;

public class VisitService
{
    public int VisitId { get; set; }
    public Visit Visit { get; set; } = null!;

    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;

    public decimal ServiceFee { get; set; }
}