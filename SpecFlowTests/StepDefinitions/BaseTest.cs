namespace ToDoListTests.SpecFlowTests.StepDefinitions
{
    [Binding]
    public class BaseTest
    {
        protected const string Url = "http://localhost:5050/api/ToDoList";

        protected RestClient client = null;
        protected RestRequest request = null;
        protected static RestResponse response;
    }
}
