namespace ToDoListTests.SpecFlowTests.StepDefinitions
{
    [Binding]
    public sealed class Hooks
    {
        private const string Url = "http://localhost:5050/api/ToDoList";
        private string json = File.ReadAllText("TestData\\ToDoListData.json");

        [AfterScenario]
        public void AfterScenario()
        {
            this.ExecuteDeleteRequest(Url, "");
            this.ExecutePostRequest(Url, "", json);
        }

        private void ExecuteDeleteRequest(string url, string resource)
        {
            var client = new RestClient(url);
            var request = new RestRequest(resource, Method.Delete);

            client.Execute(request);
        }

        private void ExecutePostRequest(string url, string resource, string jsonBody)
        {
            var client = new RestClient(url);
            var request = new RestRequest(resource, Method.Post);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            client.Execute(request);
        }
    }
}