namespace ToDoListTests.Tests
{
    public class PostToDoListTests : BaseTest
    {
        [Fact]
        public void PostToDoListTest()
        {
            var json = File.ReadAllText("TestData\\ToDoListData.json");
            var expectedData = JsonConvert.DeserializeObject<List<ToDoListModel>>(json);

            var response = this.ExecutePostRequest(Url, "", json);
            var responseData = JsonConvert.DeserializeObject<List<ToDoListModel>>(response.Content);

            HttpStatusCode.Created.Should().Be(response.StatusCode);
            expectedData.Should().BeEquivalentTo(responseData);

            var expectedDataJson = File.ReadAllText("TestData\\UpdatedPostToDoListData.json");
            expectedData = JsonConvert.DeserializeObject<List<ToDoListModel>>(expectedDataJson);

            response = this.ExecuteGetRequest(Url);
            responseData = JsonConvert.DeserializeObject<List<ToDoListModel>>(response.Content);

            HttpStatusCode.OK.Should().Be(response.StatusCode);
            expectedData.Should().BeEquivalentTo(responseData);
        }

        [Fact]
        public void PostToDoListItemTest()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 100);

            var jsonData = new
            {
                Text = "Wash the dog",
                Priority = 5
            };
            var responseJsonData = new
            {
                Text = "Wash the dog",
                Id = 4,
                Priority = 5
            };

            string jsonBody = JsonConvert.SerializeObject(jsonData);
            string responseJsonBody = JsonConvert.SerializeObject(responseJsonData);

            var response = this.ExecutePostRequest(Url, $"/{randomNumber}", jsonBody);

            HttpStatusCode.Created.Should().Be(response.StatusCode);
            responseJsonBody.Should().BeEquivalentTo(response.Content);

            var expectedDataJson = File.ReadAllText("TestData\\UpdatedPostToDoListItemData.json");
            var expectedData = JsonConvert.DeserializeObject<List<ToDoListModel>>(expectedDataJson);

            response = this.ExecuteGetRequest(Url);
            var responseData = JsonConvert.DeserializeObject<List<ToDoListModel>>(response.Content);

            expectedData.Should().BeEquivalentTo(responseData);
        }

        [Fact]
        public void PostToDoListItemWithoutPriorityTest()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 100);

            var jsonData = new
            {
                Text = "Wash the dog"
            };
            var responseJsonData = new
            {
                Text = "Wash the dog",
                Id = 4,
                Priority = 0
            };

            string jsonBody = JsonConvert.SerializeObject(jsonData);
            string responseJsonBody = JsonConvert.SerializeObject(responseJsonData);

            var response = this.ExecutePostRequest(Url, $"/{randomNumber}", jsonBody);

            HttpStatusCode.Created.Should().Be(response.StatusCode);
            responseJsonBody.Should().BeEquivalentTo(response.Content);

            var expectedDataJson = File.ReadAllText("TestData\\UpdatedPostToDoListItemWithoutPriorityData.json");
            var expectedData = JsonConvert.DeserializeObject<List<ToDoListModel>>(expectedDataJson);

            response = this.ExecuteGetRequest(Url);
            var responseData = JsonConvert.DeserializeObject<List<ToDoListModel>>(response.Content);

            expectedData.Should().BeEquivalentTo(responseData);
        }

        [Fact]
        public void PostToDoListItemWithoutTextTest()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 100);

            var jsonData = new
            {
                Priority = 5
            };

            string jsonBody = JsonConvert.SerializeObject(jsonData);

            var response = this.ExecutePostRequest(Url, $"/{randomNumber}", jsonBody);

            HttpStatusCode.BadRequest.Should().Be(response.StatusCode);

            var expectedDataJson = File.ReadAllText("TestData\\ToDoListData.json");
            var expectedData = JsonConvert.DeserializeObject<List<ToDoListModel>>(expectedDataJson);

            response = this.ExecuteGetRequest(Url);
            var responseData = JsonConvert.DeserializeObject<List<ToDoListModel>>(response.Content);

            expectedData.Should().BeEquivalentTo(responseData);
        }

        [Fact]
        public void PostToDoListEmptyItemTest()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 100);

            var response = this.ExecutePostRequest(Url, $"/{randomNumber}", String.Empty);

            HttpStatusCode.BadRequest.Should().Be(response.StatusCode);

            var expectedDataJson = File.ReadAllText("TestData\\ToDoListData.json");
            var expectedData = JsonConvert.DeserializeObject<List<ToDoListModel>>(expectedDataJson);

            response = this.ExecuteGetRequest(Url);
            var responseData = JsonConvert.DeserializeObject<List<ToDoListModel>>(response.Content);

            expectedData.Should().BeEquivalentTo(responseData);
        }
    }
}
