    internal class NewIdeaDto
        {
            public NewIdeaDto(string name, string description, int sessionId)
            {
                Name = name;
                Description = description;
                SessionId = sessionId;
            }
            public string Name { get; set; }
            public string Description { get; set; }
            public int SessionId { get; set; }
        }
    //Arrange
    var newIdea = new NewIdeaDto("Name", "", 1);
    // Act
    var response = await _client.PostAsJsonAsync("/api/ideas/create", newIdea);
    // Assert
    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
