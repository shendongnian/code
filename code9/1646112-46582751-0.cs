    public static async Task DalSoft(string SessionID, string TestStatus)
    {
      string Uri = "https://www.browserstack.com/automate/sessions/" + SessionID +    
      ".json";
    
      string AuthToken = "Basic " +  
      Convert.ToBase64String(Encoding.Default.GetBytes("username:password"));
      
      dynamic client = new DalSoft.RestClient.RestClient(Uri);
                
      var status = new { status=TestStatus };
    
      var result = await client
          .Headers(new { Authorization = AuthToken })
          .Patch(status);
    
          string Myresults = result.ToString();
    }
