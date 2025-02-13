

using Microsoft.EntityFrameworkCore;
using Vehicle.Data;
using Vehicle.IControllers;
using Vehicle.Models;

namespace Vehicle.Repository {
  public class CarRepository : ICar {

    private readonly VehicleDBContext _context;
    private readonly string ErrorContainer = "CarRepository";
    public CarRepository(VehicleDBContext context) {_context = context;}

    public async Task<bool> AddCar(Car car) {
      try {
          await _context.cars.AddAsync(car);
          return true;
      } catch (Exception e) {
        Console.WriteLine(ErrorContainer + e);
        return false;
      }
    }

    public async Task<bool> UpdateCarModel(int id, string model) {
      try {
        var data = await _context.cars.FindAsync(id);
        if (data == null) return false;

        data.Model = model;
        await _context.SaveChangesAsync();
        
        return true;

      } catch (Exception e) {
        Console.WriteLine(ErrorContainer + e);
        return false;
      }
    }

    public async Task<bool> DeleteCar(int CarId) {
      try {

        var car = await _context.cars.FindAsync(CarId);
        if (car == null) return false;
        _context.cars.Remove(car);
        return true;

      } catch (Exception e) {
         Console.WriteLine(ErrorContainer + e);
        return false;
      } 
    }


    public async Task<IEnumerable<Car>> GetCars() {
      try {
        var car = await _context.cars.ToListAsync();
        // if (car == null) return false;
        return car;
        // return true;

      } catch (Exception e) {
         Console.WriteLine(ErrorContainer + e);
        return [];
      } 
    }

    public async Task<IEnumerable<Car>> GetCarWithMostMaintanceInDateRange(DateTime start, DateTime end) {
      try {

        // var val = await _context.cars.Where(x => x.MaintenanceRecords.Any(y => y.Date.))

        return [];

      } catch (Exception e) {
        Console.WriteLine(ErrorContainer + e);
        return [];
      }
    }

  }
}