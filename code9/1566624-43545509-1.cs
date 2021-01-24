    try
    {
       var model = new someModel{ fill properties of model };
       var service = new SomeService();
       service.DoSomething(model);
       DoOtherStuff();
    }
    catch(CustomException ex)
    {
      ShowMessageToUser(ex.Message);
    }
