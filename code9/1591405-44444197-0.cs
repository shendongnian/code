    using System.Diagnostics;
    try  
    {
        // do stuff
    }
    catch (Exception e)
    {
        Debug.WriteLine(e.GetType());  // Displays the type of exception
        Debug.WriteLine(e.Message());  // Displays the exception message
    }
