namespace ToDoListTests.Tests
{
    public class GetToDoListTests : BaseTest
    {
        [Fact]
        public void GetAllToDoListTest()
        {
            var client = new RestClient(Url);
            var request = new RestRequest();
            var response = client.Execute(request);

            var responseData = JsonConvert.DeserializeObject<List<ToDoListModel>>(response.Content);

            var expectedDataJson = File.ReadAllText("TestData\\ToDoListData.json");
            var expectedData = JsonConvert.DeserializeObject<List<ToDoListModel>>(expectedDataJson);

            (HttpStatusCode.OK).Should().Be(response.StatusCode);
            expectedData.Should().BeEquivalentTo(responseData);
        }

        [Fact]
        public void GetToDoListItemTest()
        {
            int item = 1;

            var client = new RestClient(Url + $"/{item}");
            var request = new RestRequest();
            var response = client.Execute(request);

            var responseData = JsonConvert.DeserializeObject<ToDoListModel>(response.Content);

            var expectedDataJson = File.ReadAllText("TestData\\ToDoListData.json");
            var expectedData = JsonConvert.DeserializeObject<List<ToDoListModel>>(expectedDataJson)[item - 1];

            (HttpStatusCode.OK).Should().Be(response.StatusCode);
            expectedData.Should().BeEquivalentTo(responseData);
        }
    }
}
