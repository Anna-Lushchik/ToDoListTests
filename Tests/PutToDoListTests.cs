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

            var client = new RestClient(Url);
            var request = new RestRequest($"/{item}", Method.Put);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
            var response = client.Execute(request);

            (HttpStatusCode.OK).Should().Be(response.StatusCode);
            jsonBody.Should().BeEquivalentTo(response.Content);

            var requestGet = new RestRequest();
            response = client.Execute(requestGet);
            var responseData = JsonConvert.DeserializeObject<List<ToDoListModel>>(response.Content);

            var expectedDataJson = File.ReadAllText("TestData\\UpdatedPutToDoListData.json");
            var expectedData = JsonConvert.DeserializeObject<List<ToDoListModel>>(expectedDataJson);

            expectedData.Should().BeEquivalentTo(responseData);
        }
    }
}
