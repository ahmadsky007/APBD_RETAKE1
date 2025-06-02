using Microsoft.EntityFrameworkCore;
using WorkshopVisitsApi.Models;

namespace WorkshopVisitsApi.Data;

public class WorkshopVisitsContext : DbContext
{
    public WorkshopVisitsContext(DbContextOptions<WorkshopVisitsContext> options) : base(options)
    {
    }

    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Mechanic> Mechanics => Set<Mechanic>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<Visit> Visits => Set<Visit>();
    public DbSet<VisitService> VisitServices => Set<VisitService>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Composite key for VisitService
        modelBuilder.Entity<VisitService>()
            .HasKey(vs => new { vs.VisitId, vs.ServiceId });

        // Visit -> Client
        modelBuilder.Entity<Visit>()
            .HasOne(v => v.Client)
            .WithMany(c => c.Visits)
            .HasForeignKey(v => v.ClientId);

        // Visit -> Mechanic
        modelBuilder.Entity<Visit>()
            .HasOne(v => v.Mechanic)
            .WithMany(m => m.Visits)
            .HasForeignKey(v => v.MechanicId);

        // VisitService -> Visit
        modelBuilder.Entity<VisitService>()
            .HasOne(vs => vs.Visit)
            .WithMany(v => v.VisitServices)
            .HasForeignKey(vs => vs.VisitId);

        // VisitService -> Service
        modelBuilder.Entity<VisitService>()
            .HasOne(vs => vs.Service)
            .WithMany(s => s.VisitServices)
            .HasForeignKey(vs => vs.ServiceId);
    }
}