using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using MyApi.Models.Context;

namespace KiloNx.Apps.MyApi.MyApi.Controllers;

public class TodoItemsController(MyApiContext context) : ControllerBase
{
  [HttpPost("/")]
  [ProducesResponseType(StatusCodes.Status201Created)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
  {
    context.TodoItems.Add(todoItem);
    await context.SaveChangesAsync();

    //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
    return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
  }

  [HttpGet("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public ActionResult<TodoItem> GetTodoItem(long id)
  {
    var todoItem = context.TodoItems.Find(id);

    if (todoItem == null)
    {
      return NotFound();
    }

    return todoItem;
  }

}
