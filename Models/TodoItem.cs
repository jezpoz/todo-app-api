namespace Todo.Models;

public class TodoItem
{
  public string Id { get; set; } = "";
  public string Title { get; set; } = "";

  public bool Done { get; set; }

  public DateTime Created { get; set; }

  public DateTime? Finished { get; set; }
}


