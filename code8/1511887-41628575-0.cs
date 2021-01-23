    var someDisposableObject = null;
    
    try
    {
        someDisposableObject = new SomeDisposableObject(); //documented to be able to throw SomethingBadHappenedException
        return someDisposableObject.DoSomethingDangerous(); //documented to be able to throw SomethingBadHappenedException 
    }
    catch (SomethingBadHappenedException e)
    {
        Logger.Log(e);
        InformUserSomethingWentWrong(e);
        return null;
    }
    finally
    {
        if (someDisposableObject != null)
        {
            someDisposableObject.Dispose();
        }
    }
