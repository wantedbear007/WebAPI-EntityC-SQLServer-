

using Microsoft.EntityFrameworkCore;
using Vehicle.Data;
using Vehicle.IControllers;
using Vehicle.Models;

namespace Vehicle.Repository
{
  public class OwnerRepository : IOwner
  {

    private readonly VehicleDBContext _context;
    private readonly static string ErrorContainer = "OwnerRepository";

    public OwnerRepository(VehicleDBContext context) { _context = context; }

    public async Task<IEnumerable<Owner>> GetOwnerWithMostVehicle(int topN)
    {
      try
      {
        var data = await _context.owners.OrderByDescending(v => v.cars.Count).Take(topN).ToListAsync();
        return data;
      }
      catch (Exception e)
      {
        Console.WriteLine(ErrorContainer + e.ToString());
        return [];
      }
    }
    public async Task<IEnumerable<Owner>> GetOwnerWithOldestVehicle()
    {
      try
      {
        var data = await _context.owners.Where(x => x.cars.Any()).OrderBy(x => x.cars.Min(y => y.Year)).ToListAsync();
        return data;

      }
      catch (Exception e)
      {
        Console.WriteLine(ErrorContainer + e.ToString());
        return [];
      }
    }
    public async Task<IEnumerable<Owner>> GetOwnersWithHighestAverageMaintenanceCost()
    {
      try
      {
        var data = await _context.owners
          .Where(o => o.cars.Any())
          .OrderByDescending(o => o.cars.Average(v => v.MaintenanceRecords.Average(m => m.Cost)))
          .ToListAsync(); ;

        return data;
      }
      catch (Exception e)
      {
        Console.WriteLine(ErrorContainer + e.ToString());
        return [];
      }
    }
  }
}