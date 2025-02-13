


using Vehicle.Models;

namespace Vehicle.IControllers {
  public interface IOwner {
    Task<IEnumerable<Owner>> GetOwnerWithMostVehicle(int topN);
    Task<IEnumerable<Owner>> GetOwnerWithOldestVehicle();
    Task<IEnumerable<Owner>> GetOwnersWithHighestAverageMaintenanceCost();
  }
}