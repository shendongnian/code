    [Test]
    public async Task GetExchange_GetView_OkModelIsViewModel() {
        // ...
        var controller = new SomeController(fakeUnitOfWorkFactory);
        var result = await controller.SomeMethod(); // call using await
        // ...
    }
