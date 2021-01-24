    string url ="http://www.whatever.example.com/Function.php";
    
    var reqparam = new System.Collections.Specialized.NameValueCollection();
    
    reqparam.Add("name", "John Doe");
    
    try
    {
        using (System.Net.WebClient client = new System.Net.WebClient())
        {
    
         byte[] responsebytes = client.UploadValues(url, "POST", parameters);
    
         string output = System.Text.Encoding.UTF8.GetString(responsebytes);
                
         }
    }
    catch (Exception x)
    {
       //an error occured
    }
