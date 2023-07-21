namespace ToDoListTests.SpecFlowTests.StepDefinitions
{
    [Binding]
    public class GetToDoList : BaseTest
    {
        [Given(@"I Set GET ToDoList api endpoint")]
        public void SetGetRequest()
        {
            client = new RestClient(Url);
            request = new RestRequest();
        }

        [Given(@"I Set GET ToDoList (.*) api endpoint")]
        public void SetGetRequestForItem(int item)
        {
            client = new RestClient(Url + $"/{item}");
            request = new RestRequest();
        }

        [When(@"I Send GET HTTP request")]
        public void ExecuteRequest()
        {
            response = client.Execute(request);
        }
    }
}
