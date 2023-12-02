using Microsoft.AspNetCore.Mvc;
using MyApi.Models;

namespace KiloNx.Apps.MyApi.MyApi.Controllers;

public class TodoItemsController : Controller
{
  [HttpPost]
  public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
  {
    _context.TodoItems.Add(todoItem);
    await _context.SaveChangesAsync();

    //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
    return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
  }
}
