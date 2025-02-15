

using Microsoft.EntityFrameworkCore;
using Vehicle.Data;
using Vehicle.IControllers;
using Vehicle.IRepository;
using Vehicle.Models;

namespace Vehicle.Repository {
  public class CarRepository : ICar {
    private readonly VehicleDBContext _carContext;
    private readonly string ErrorContainer = "CarRepository";
    public CarRepository(VehicleDBContext context) {_carContext = context;}

    public async Task<bool> AddCar(Car car) { 
      try {
        // insert into student (id, name) values (1, "bhanu");
          var res = await _carContext.cars.AddAsync(car);
          _carContext.SaveChanges();
          Console.WriteLine("add response is: " + res);
          return true;
      } catch (Exception e) {
        Console.WriteLine(ErrorContainer + e);
        return false;
      }
    }

    public async Task<bool> UpdateCarModel(int id, string model) {
      try {
        var data = await _carContext.cars.FindAsync(id);
        if (data == null) return false;

        data.Model = model;
        await _carContext.SaveChangesAsync();
        
        return true;

      } catch (Exception e) {
        Console.WriteLine(ErrorContainer + e);
        return false;
      }
    }

    public async Task<bool> DeleteCar(int CarId) {
      try {

        var car = await _carContext.cars.FindAsync(CarId);
        if (car == null) return false;
        _carContext.cars.Remove(car);
        return true;

      } catch (Exception e) {
         Console.WriteLine(ErrorContainer + e);
        return false;
      } 
    }


    public async Task<IEnumerable<Car>> GetCars() {
      try {
        var car =  await _carContext.cars.ToListAsync();
        Console.WriteLine("cars are: " + car);
        return car;

      } catch (Exception e) {
         Console.WriteLine(ErrorContainer + e);
        return [];
      } 
    }

    public async Task<IEnumerable<Car>> GetCarWithMostMaintanceInDateRange(DateTime start, DateTime end) {
      try {

        // var val = await _carContext.cars.Where(x => x.MaintenanceRecords.Any(y => y.Date.))

        return [];

      } catch (Exception e) {
        Console.WriteLine(ErrorContainer + e);
        return [];
      }
    }

  }
}