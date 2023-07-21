namespace ToDoListTests.SpecFlowTests.StepDefinitions
{
    [Binding]
    public class ResponseCode : BaseTest
    {
        [Then(@"I recive valid HTTP response code 200")]
        public void VerifyResponseCode200()
        {
            HttpStatusCode.OK.Should().Be(response.StatusCode);
        }

        [Then(@"I recive NotFound HTTP response code 404")]
        public void VerifyResponseCode404()
        {
            HttpStatusCode.NotFound.Should().Be(response.StatusCode);
        }
    }
}
