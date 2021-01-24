    public async Task Test() {
        var controller = new Controller(mockService.Object);
        var model = new MyObject
        {
            Address = "12.12.12.12",
            Password = "123456",
            Username = "John Foo"
        };
        var res = await controller.Add(model);
    }
