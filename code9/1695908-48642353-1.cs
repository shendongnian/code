    try
    {
        WebResponse response = request.GetResponse(); 
        
        ...
        ...
    }
    catch(WebException ex)
    {
        // inspect Response and Status properties
    }
