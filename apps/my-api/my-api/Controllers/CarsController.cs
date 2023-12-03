using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using MyApi.Models.Context;

namespace KiloNx.Apps.MyApi.MyApi.Controllers;

public class CarsController(MyApiContext context) : ControllerBase
{
  [Microsoft.AspNetCore.Mvc.HttpPost("cars/")]
  [ProducesResponseType(StatusCodes.Status201Created)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<ActionResult<Car>> PostCar(Car car)
  {
    context.Car.Add(car);
    await context.SaveChangesAsync();

    //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
    return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
  }

  [HttpGet("cars/{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public ActionResult<Car> GetCar(long id)
  {
    var todoItem = context.Car.Find(id);

    if (todoItem == null)
    {
      return NotFound();
    }

    return todoItem;
  }

}
