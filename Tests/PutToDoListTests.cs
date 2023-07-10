namespace ToDoListTests.Tests
{
    public class PutToDoListTests : BaseTest
    {
        [Fact]
        public void PutToDoListItemTest()
        {
            int item = 2;

            var jsonData = new
            {
                Text = "Сlean up the bathroom",
                Id = item,
                Priority = 4
            };

            string jsonBody = JsonConvert.SerializeObject(jsonData);

            var response = this.ExecutePutRequest(Url, $"/{item}", jsonBody);
            
            HttpStatusCode.OK.Should().Be(response.StatusCode);
            jsonBody.Should().BeEquivalentTo(response.Content);

            var expectedDataJson = File.ReadAllText("TestData\\UpdatedPutToDoListData.json");
            var expectedData = JsonConvert.DeserializeObject<List<ToDoListModel>>(expectedDataJson);

            response = this.ExecuteGetRequest(Url);
            var responseData = JsonConvert.DeserializeObject<List<ToDoListModel>>(response.Content);
                        
            expectedData.Should().BeEquivalentTo(responseData);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        public void PutToDoListNotExistedItemTest(int item)
        {
            var jsonData = new
            {
                Text = "Сlean up the bathroom",
                Id = item,
                Priority = 4
            };

            string jsonBody = JsonConvert.SerializeObject(jsonData);

            var response = this.ExecutePutRequest(Url, $"/{item}", jsonBody);

            HttpStatusCode.NotFound.Should().Be(response.StatusCode);
        }
    }
}
