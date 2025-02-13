

using Vehicle.Models;

namespace Vehicle.IControllers {
  public interface ICar {
    Task<IEnumerable<Car>> GetCars();
    Task<bool> AddCar(Car car);
    Task<bool> UpdateCarModel(int id, string model);
    Task<bool> DeleteCar(int CarId);
    Task<IEnumerable<Car>> GetCarWithMostMaintanceInDateRange(DateTime start, DateTime end);
  }
}