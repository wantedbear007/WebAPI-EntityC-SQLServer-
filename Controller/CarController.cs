

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Vehicle.IControllers;
using Vehicle.Models;
using Vehicle.Repository;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{

  private readonly ICar _carContext;

  public CarController(ICar carContext)
  {
    _carContext = carContext;
  }

  [HttpGet]
  public async Task<IActionResult> GetCar() {
    return Ok(await _carContext.GetCars());
  }

  [HttpPost]
  public async Task<IActionResult> AddCar(Car car)
  {
    var res = await _carContext.AddCar(car);

    if (res)
    {
      return Ok("Car added successfully");
    }
    else
    {
      return BadRequest("Failed to add car");
    }
  }

  [HttpPut("{id}/{model}")]
  public async Task<IActionResult> UpdateCarModel(int id, string model)
  {
    var res = await _carContext.UpdateCarModel(id, model);
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
    return await _carContext.DeleteCar(id) ? Ok("Car deleted ") : BadRequest("Failed to delete car");
  }

}