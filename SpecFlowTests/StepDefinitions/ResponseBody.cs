namespace ToDoListTests.SpecFlowTests.StepDefinitions
{
    [Binding]
    public class ResponseBody : BaseTest
    {
        string BaseJson = File.ReadAllText("TestData\\ToDoListData.json");

        [Then(@"I receive valid Response Body")]
        public void VerifyResponseBody()
        {
            var expectedData = JsonConvert.DeserializeObject<List<ToDoListModel>>(BaseJson);

            var responseData = JsonConvert.DeserializeObject<List<ToDoListModel>>(response.Content);
            expectedData.Should().BeEquivalentTo(responseData);
        }

        [Then(@"I receive valid Response Body for (.*)")]
        public void VerifyResponseBody(int item)
        {
            var expectedData = JsonConvert.DeserializeObject<List<ToDoListModel>>(BaseJson)[item - 1];
            var responseData = JsonConvert.DeserializeObject<ToDoListModel>(response.Content);

            expectedData.Should().BeEquivalentTo(responseData);
        }
    }
}
