using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{

  [HttpGet(Name = "GetTodos")]
  public IEnumerable<Models.Todo> Get()
  {
    List<Models.Todo> todos = new List<Models.Todo>();
    for (int i = 0; i < 10; i++)
    {
      DateTime created = DateTime.Now;
      todos.Add(new Models.Todo
      {
        Title = "Todo: " + i,
        Done = i % 2 == 0,
        Created = created.AddHours(i),
        Finished = i % 2 == 0 ? created.AddHours(i + 1) : null,
      });
    }
    return todos.ToArray();
  }
}