

using Microsoft.EntityFrameworkCore;
using Vehicle.Data;
using Vehicle.Models;

namespace Vehicle.Repository {
  public class MaintenanceRecordRepository {
    private readonly VehicleDBContext _context;
    private readonly string ErrorContainer = "MaintainanaceRecordError"; 
    public MaintenanceRecordRepository(VehicleDBContext context) {_context = context;}

    public async Task<IEnumerable<MaintenanceRecord>> GetMaintenanceRecordsByVehicle(int VehicleId) {
      try {
          return await _context.maintenanceRecords.Where(x => x.CarId == VehicleId).ToListAsync();
      } catch (Exception e) {
        Console.WriteLine(ErrorContainer +  e);
        return [];
      }
    }
    public async Task<IEnumerable<MaintenanceRecord>> GetMaintenanceRecordsByMake(string make) {
      try {
        return await _context.maintenanceRecords.Where(y => y.car.Make == make).ToListAsync();
      } catch (Exception e) {
        Console.WriteLine(ErrorContainer +  e);
        return [];
      }
    }


    public async Task<MaintenanceRecord> GetMaintenanceRecordForOwner(int ownerId) {
        try {
        return await _context.maintenanceRecords.Where(x => x.car.OwnerId == ownerId).FirstOrDefaultAsync();
      } catch (Exception e) {
        Console.WriteLine(ErrorContainer +  e);
        return null;
      }
    }

  }
}