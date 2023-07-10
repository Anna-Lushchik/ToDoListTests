[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace ToDoListTests.Tests
{
    public class BaseTest : IDisposable
    {
        public const string Url = "http://localhost:5050/api/ToDoList";

        public void Dispose()
        {
            var json = File.ReadAllText("TestData\\ToDoListData.json");

            this.ExecuteDeleteRequest(Url, "");
            this.ExecutePostRequest(Url, "", json);
        }

        protected RestResponse ExecuteGetRequest(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest();

            return client.Execute(request);
        }

        protected RestResponse ExecuteDeleteRequest(string url, string resource)
        {
            var client = new RestClient(url);
            var request = new RestRequest(resource, Method.Delete);

            return client.Execute(request);
        }

        protected RestResponse ExecutePostRequest(string url, string resource, string jsonBody)
        {
            var client = new RestClient(url);
            var request = new RestRequest(resource, Method.Post);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            return client.Execute(request);
        }

        protected RestResponse ExecutePutRequest(string url, string resource, string jsonBody)
        {
            var client = new RestClient(url);
            var request = new RestRequest(resource, Method.Put);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            return client.Execute(request);
        }
    }
}
