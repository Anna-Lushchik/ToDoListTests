namespace ToDoListTests.Tests
{
    public class DeleteToDoListTests : BaseTest
    {
        [Fact]
        public void DeleteAllToDoListTest()
        {
            var emptyList = new List<ToDoListModel>();

            var client = new RestClient(Url);
            var request = new RestRequest("", Method.Delete);
            var response = client.Execute(request);

            (HttpStatusCode.OK).Should().Be(response.StatusCode);
            (String.Empty).Should().BeEquivalentTo(response.Content);

            var requestGet = new RestRequest();
            response = client.Execute(requestGet);
            var responseData = JsonConvert.DeserializeObject<List<ToDoListModel>>(response.Content);

            emptyList.Should().BeEquivalentTo(responseData);
        }

        [Fact]
        public void DeleteToDoListItemTest()
        {
            int item = 1;

            var client = new RestClient(Url);
            var requestDelete = new RestRequest($"/{item}", Method.Delete);
            var response = client.Execute(requestDelete);

            (HttpStatusCode.OK).Should().Be(response.StatusCode);
            String.Empty.Should().BeEquivalentTo(response.Content);

            var requestGet = new RestRequest();
            response = client.Execute(requestGet);

            var responseData = JsonConvert.DeserializeObject<List<ToDoListModel>>(response.Content);

            var expectedDataJson = File.ReadAllText("TestData\\ToDoListData.json");
            var expectedData = JsonConvert.DeserializeObject<List<ToDoListModel>>(expectedDataJson);
            expectedData?.RemoveAt(item - 1);

            expectedData.Should().BeEquivalentTo(responseData);
        }
    }
}
