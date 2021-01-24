    [TestMethod]
    public void Should_return_a_valid_json_result() {
        // Arrange
        var search = new Search();
        search.Area = "test";
        var json = JsonConvert.SerializeObject(search);
        var request = new HttpRequestMessage();
        request.Method = HttpMethod.Post;
        request.Content = new StringContent(json);
        var controller = new UserController();
        controller.Request = request;
        //more code
    }
