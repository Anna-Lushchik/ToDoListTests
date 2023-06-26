[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace ToDoListTests.Tests
{
    public class BaseTest : IDisposable
    {
        public const string Url = "http://localhost:5050/api/ToDoList";

        public void Dispose()
        {
            var client = new RestClient(Url);
            var request = new RestRequest("", Method.Delete);
            client.Execute(request);

            var json = File.ReadAllText("TestData\\ToDoListData.json");

            request = new RestRequest("", Method.Post);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            client.Execute(request);
        }
    }
}
