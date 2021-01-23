    public async Task<MyDisposeableClass> CreateDisposableAsync()
    {
        MyDisposeableClass myDisposeableClass = null;
        try
        {
            myDisposeableClass = new MyDisposeableClass();
            //...
    
            return myDisposeableClass;
        }
        catch
        {
            //dispose of the class if the instance was created.
            if(myDisposeableClass != null)
                myDisposeableClass.Dispose();
    
            //let the execption bubble up.
            throw;
        }
    }
