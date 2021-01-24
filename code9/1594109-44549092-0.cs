    DisposableObject holdon = null;
    
    {
        DisposableObject o = new DisposableObject()
        try
        {
            Console.WriteLine("Inside using block");
            holdon = o;
        }
        finally
        {
            if(o != null)
            o.Dispose();
        }
    
    }
    
    holdon.Method();
