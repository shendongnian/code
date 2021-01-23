    public void Execute(YourObject obj)
    {
        obj.SomeMethod();
    }
    var newObject = new YourObjectWithExtraLogic();
    Execute(newObject);
