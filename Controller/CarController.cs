

using Microsoft.AspNetCore.Mvc;
using Vehicle.IControllers;
using Vehicle.IRepository;
using Vehicle.Models;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
  private readonly ICar _carRepository;


  public CarController(ICar carContext)
  {
    _carRepository = carContext;
  }

  [HttpGet]
  public async Task<IActionResult> GetCar()
  {
    var vehicles = await _carRepository.GetCars();
    if (vehicles == null) {
      return BadRequest();
    } else {
      return Ok(vehicles);
    }
  }

  [HttpPost]
  public async Task<IActionResult> AddCar()
  {

    var carr = new Car
    {
      id = 1,
      Make = "Toyota",
      Model = "Camry",
      Year = 2022,
      OwnerId = 10,
      owner = new Owner
      {
        Id = 10,
        Name = "John Doe",
        Address = "123 Main St",
        cars = new List<Car>() // This can be populated if needed
      },
      MaintenanceRecords = new List<MaintenanceRecord>
    {
        new MaintenanceRecord
        {
            Id = 1,
            Date = DateTime.Parse("2024-02-13"),
            Cost = 200.50m,
            Description = "Oil change",
            CarId = 1,
            car = null
        }
    }
    };

    var res = await _carRepository.AddCar(carr);

    if (res)
    {
      return Ok("Car added successfully");
    }
    else
    {
      return BadRequest("Failed to add car");
      // return Ok("Car added successfully");

    }
  }

  [HttpPut("{id}/{model}")]
  // api/car/1/abc 
  public async Task<IActionResult> UpdateCarModel(int id, string model)
  {
    var res = await _carRepository.UpdateCarModel(id, model);
    if (res)
    {
      return Ok("Model updated successfully");
    }
    else
    {
      return BadRequest("Failed to update car model");
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteCar(int id)
  {
    var res = await _carRepository.DeleteCar(id);
    if (res) {
      return Ok("Car deleted !");
    } else {return BadRequest();}
    // return await _carRepository.DeleteCar(id) ? Ok("Car deleted ") : BadRequest("Failed to delete car");
  }

}