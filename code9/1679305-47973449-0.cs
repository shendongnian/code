     Dictionary<string, string> myDictionary = new Dictionary<string, string>();
     if (req.Content.Headers.ContentType.ToString().ToLower().Equals("application/x-www-form-urlencoded"))
      {
          var body = req.Content.ReadAsStringAsync().Result;
          var array = body.Split('&');
          foreach (var item in array)
          {
                var keyvalue = item.Split('=');
                myDictionary.Add(keyvalue[0],keyvalue[1]);
           }
    
      }
     var sid = myDictionary["SmsMessageSid"];
     log.Info($"sid ={sid}");
     return req.CreateResponse(HttpStatusCode.OK, $"Current Time : {DateTime.Now}"); 
