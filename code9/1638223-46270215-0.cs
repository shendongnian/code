    public async Task GetUserShouldReturnOk() {
        var userId = new Guid();
        var configuration = Mock.Of<IConfiguration>(_ =>
             _.GetConnectionString("DefaultConnection") == "connection string here");
    
        var controller = new MyController(
            new MyRepository(configuration));
    
        var result = await controller.GetUser(userId);
    
        Assert.IsType<OkResult>(result);
    }
