    using System.Net; 
   
    // Implementation 
    try
    {
        using (WebClient client = new WebClient())
        {
           using (client.OpenRead("http://www.google.com/"))
           {
              // success
           }
        }
    }
    catch
    {
        // Raise an event
        // you might want to check for consistent failures 
        // before signalling the Internet is down
    }
