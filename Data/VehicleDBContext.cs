

using Microsoft.EntityFrameworkCore;
using Vehicle.Models;

namespace Vehicle.Data {
  public class VehicleDBContext : DbContext {
      public VehicleDBContext(DbContextOptions<VehicleDBContext> options) : base(options) {}
      public DbSet<Car> cars {get; set;}
      public DbSet<MaintenanceRecord> maintenanceRecords {get; set;}
      public DbSet<Owner> owners {get; set;}
  }
} 