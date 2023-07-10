namespace ToDoListTests.Tests
{
    public class DeleteToDoListTests : BaseTest
    {
        [Fact]
        public void DeleteAllToDoListTest()
        {
            var response = this.ExecuteDeleteRequest(Url, "");

            HttpStatusCode.NoContent.Should().Be(response.StatusCode);
            String.Empty.Should().BeEquivalentTo(response.Content);

            response = this.ExecuteGetRequest(Url);

            HttpStatusCode.NotFound.Should().Be(response.StatusCode);
        }

        [Fact]
        public void DeleteToDoListItemTest()
        {
            int item = 1;

            var response = this.ExecuteDeleteRequest(Url, $"/{item}");

            HttpStatusCode.NoContent.Should().Be(response.StatusCode);
            String.Empty.Should().BeEquivalentTo(response.Content);

            var expectedDataJson = File.ReadAllText("TestData\\ToDoListData.json");
            var expectedData = JsonConvert.DeserializeObject<List<ToDoListModel>>(expectedDataJson);
            expectedData?.RemoveAt(item - 1);

            response = this.ExecuteGetRequest(Url);
            var responseData = JsonConvert.DeserializeObject<List<ToDoListModel>>(response.Content);

            expectedData.Should().BeEquivalentTo(responseData);

            response = this.ExecuteGetRequest(Url + $"/{item}");

            HttpStatusCode.NotFound.Should().Be(response.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        public void DeleteToDoListNotExistedItemTest(int item)
        {
            var response = this.ExecuteDeleteRequest(Url, $"/{item}");

            HttpStatusCode.NotFound.Should().Be(response.StatusCode);
        }
    }
}
