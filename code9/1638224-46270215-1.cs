    public async Task GetUserShouldReturnOk() {
        var userId = new Guid();
        var configuration = new ConfigurationBuilder()
                .SetBasePath("Set path to folder containing appsettings.json")
                .AddJsonFile("appsettings.json")
                .Build();
    
        var controller = new MyController(
            new MyRepository(configuration));
    
        var result = await controller.GetUser(userId);
    
        Assert.IsType<OkResult>(result);
    }
