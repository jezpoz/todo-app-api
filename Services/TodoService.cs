using Todo.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace Todo.Services {
  public class TodoService {
    private readonly CosmosService _cosmos;

    public TodoService(CosmosService cosmos) {
      _cosmos = cosmos;
    }

    public async Task<IEnumerable<TodoItem>> GetAllTodos()
    {
      var queryable = container.GetItemLinqQueryable<TodoItem>();
      using FeedIterator<TodoItem> feed = queryable
        .ToFeedIterator();
      List<TodoItem> todos = new();
      while (feed.HasMoreResults)
      {
        var response = await feed.ReadNextAsync();
        foreach (TodoItem item in response)
        {
          todos.Add(item);
        }
      }
      return todos;
    }

    public async Task<TodoItem?> GetTodoById(string id) {
      try {
        return await container.ReadItemAsync<TodoItem>(
          id: id,
          partitionKey: new PartitionKey(id)
        );
      } catch (CosmosException ex) {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Error getting Todo with ID: " + id);
        return null;
      }
    }

    private Container container
    {
      get => _cosmos.GetContainer("ToDoDb", "Todos");
    }
  }
}