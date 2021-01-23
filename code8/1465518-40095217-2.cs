    public async Task GetCharactersAsync_ById_Test()
    {
        var charDictionary = TestHelper.GetCharactersIdDictionary(1);
        var mockReq = new Mock<IRequester>();
        mockReq.Setup(x => x.CreateGetRequestAsync<Dictionary<long, Character>>
                            (It.IsAny<string>())).ReturnsAsync(charDictionary);
        var char1 = TestHelper.GetCharacter();
        var api = GameObject.GetInstance(mockReq.Object);
        var character = await api.GetCharacterAsync(TestHelper.GetRegion(), (int)char.Id);
        Assert.AreEqual(character.Name, char1.Name);
    }
