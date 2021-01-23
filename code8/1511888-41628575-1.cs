    (bool Succesful, var result) TryDoSomethingDangerous()
    {
        var someDisposableObject = null;
    
        try
        {
            someDisposableObject = new SomeDisposableObject(); //documented to be able to throw SomethingBadHappenedException
            var output = someDisposableObject.DoSomethingDangerous(); //documented to be able to throw SomethingBadHappenedException
            return (true, output);
        }
        catch (SomethingBadHappenedException e)
        {
            Logger.Log(e);
            InformUserSomethingWentWrong(e);
            return (false, null);
        }
        finally
        {
            if (someDisposableObject != null)
            {
                someDisposableObject.Dispose();
            }
        }
    }
