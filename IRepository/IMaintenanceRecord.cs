

using Vehicle.Models;

namespace Vehicle.IControllers {
  public interface IMaintenanceRecord {
    Task<IEnumerable<MaintenanceRecord>> GetMaintenanceRecordsByVehicle(int VehicleId);
    Task<IEnumerable<MaintenanceRecord>> GetMaintenanceRecordsByMake(string make);
    Task<MaintenanceRecord> GetMaintenanceRecordForOwner(int ownerId);
  }
}