    try
    {
        WebResponse response = request.GetResponse(); 
        
        ...
        ...
    }
    catch(WebException as ex)
    {
        // inspect Response and Status properties
    }
