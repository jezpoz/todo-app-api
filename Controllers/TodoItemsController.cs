using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.Services;

namespace Todo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TodoItemsController : ControllerBase
  {
    private readonly TodoService _todoService;

    public TodoItemsController(TodoService todoService)
    {
      _todoService = todoService;
    }

    // GET: api/TodoItems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodos()
    {
      var todos = await _todoService.GetAllTodos();
      return todos.ToList();
    }

    // GET: api/TodoItems/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItem>> GetTodoItem(string id)
    {
      if (string.IsNullOrEmpty(id)) {
        return BadRequest();
      }
      var todo = await _todoService.GetTodoById(id);
      if (todo != null) {
        return todo;
      }

      return NotFound();
    }
     /*
    // PUT: api/TodoItems/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
    {
      if (id != todoItem.Id)
      {
        return BadRequest();
      }

      _context.Entry(todoItem).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TodoItemExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/TodoItems
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
    {
      _context.Todos.Add(todoItem);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
    }

    // DELETE: api/TodoItems/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(long id)
    {
      if (_context.Todos == null)
      {
        return NotFound();
      }
      var todoItem = await _context.Todos.FindAsync(id);
      if (todoItem == null)
      {
        return NotFound();
      }

      _context.Todos.Remove(todoItem);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool TodoItemExists(long id)
    {
      return (_context.Todos?.Any(e => e.Id == id)).GetValueOrDefault();
    }*/
  }
}
