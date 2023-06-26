namespace ToDoListTests.Tests
{
    public class PostToDoListTests : BaseTest
    {
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

            var client = new RestClient(Url);
            var request = new RestRequest($"/{randomNumber}", Method.Post);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
            var response = client.Execute(request);

            (HttpStatusCode.OK).Should().Be(response.StatusCode);
            responseJsonBody.Should().BeEquivalentTo(response.Content);

            var requestGet = new RestRequest();
            response = client.Execute(requestGet);
            var responseData = JsonConvert.DeserializeObject<List<ToDoListModel>>(response.Content);

            var expectedDataJson = File.ReadAllText("TestData\\UpdatedPostToDoListData.json");
            var expectedData = JsonConvert.DeserializeObject<List<ToDoListModel>>(expectedDataJson);

            expectedData.Should().BeEquivalentTo(responseData);
        }
    }
}
