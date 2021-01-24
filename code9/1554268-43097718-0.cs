    async Task SomeMethod() {  }
    async Task SomeOtherMethod() {  }  
    Task task1 = SomeMethod();
    Task task2 = SomeOtherMethod();
    await Task.WhenAll(task1,task2);
    // get results task1.Result and task2.Result
