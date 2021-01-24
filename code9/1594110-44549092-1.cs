    DisposableObject holdon = null;
    
    { //This "{" is here to limit the scope of "o"
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
