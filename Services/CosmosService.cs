using Microsoft.Azure.Cosmos;

namespace Todo.Services
{
  public class CosmosService
  {
    private readonly CosmosClient _client;

    public CosmosService()
    {
      _client = new CosmosClient(
        connectionString: ""
      );
    }

    public Container GetContainer(string databaseName, string containerName) {
      return _client.GetDatabase(databaseName).GetContainer(containerName);
    }
  };
}