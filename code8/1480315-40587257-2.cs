    public void MyAction()
    {
        MyModel model = ExecuteSafely(SomeMethodThatThrowsException());
        return View(model);
    }
    
    private MyModel(Func<MyModel> action)
    {
        try
        {
           return action();
        }
        catch
        {
            // Add what you need to a model/view/etc. here
            return null;
        }
    }
