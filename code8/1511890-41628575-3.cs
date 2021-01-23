    (bool Succesful, object Result) TryDoSomethingDangerous()
    {
        var someDisposableObject = new SomeDisposableObject();
        try
        {
            var result = someDisposableObject.DoSomethingDangerous(); //documented to be able to throw SomethingBadHappenedException
            return (true, result);
        }
        catch (SomethingBadHappenedException e)
        {
            Logger.Log(e);
            InformUserSomethingWentWrong(e);
            return (false, null);
        }
        finally
        {
            someDisposableObject.Dispose();
        }
    }
