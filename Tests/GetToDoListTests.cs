namespace ToDoListTests.Tests
{
    public class GetToDoListTests : BaseTest
    {
        [Fact]
        public void GetAllToDoListTest()
        {
            var expectedDataJson = File.ReadAllText("TestData\\ToDoListData.json");
            var expectedData = JsonConvert.DeserializeObject<List<ToDoListModel>>(expectedDataJson);

            var response = this.ExecuteGetRequest(Url);
            var responseData = JsonConvert.DeserializeObject<List<ToDoListModel>>(response.Content);

            HttpStatusCode.OK.Should().Be(response.StatusCode);
            expectedData.Should().BeEquivalentTo(responseData);
        }

        [Fact]
        public void GetToDoListItemTest()
        {
            int item = 1;

            var expectedDataJson = File.ReadAllText("TestData\\ToDoListData.json");
            var expectedData = JsonConvert.DeserializeObject<List<ToDoListModel>>(expectedDataJson)[item - 1];

            var response = this.ExecuteGetRequest(Url + $"/{item}");
            var responseData = JsonConvert.DeserializeObject<ToDoListModel>(response.Content);

            HttpStatusCode.OK.Should().Be(response.StatusCode);
            expectedData.Should().BeEquivalentTo(responseData);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        public void GetToDoListNotExistedItemTest(int item)
        {
            var response = this.ExecuteGetRequest(Url + $"/{item}");

            HttpStatusCode.NotFound.Should().Be(response.StatusCode);
        }
    }
}
