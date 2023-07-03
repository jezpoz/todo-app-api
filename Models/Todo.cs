namespace Todo.Models
{
  public class Todo
  {
    private Guid Id
    {
      get { return Id; }
      set
      {
        if (value == Guid.Empty)
        {
          Id = new Guid();
        }
        else
        {
          Id = value;
        }
      }
    }
    public string Title
    {
      get { return Title; }
      set
      {
        if (string.IsNullOrEmpty(value))
        {
          value = "";
        }
        else
        {
          Title = value;
        }
      }
    }

    public bool Done { get; set; }

    public DateTime Created { get; set; }

    public Nullable<DateTime> Finished { get; set; }
  }
}

