      using Newtonsoft.json;
      Class Cats
      {
        string[] Facts {get; set;}
      } 
      var wc = new System.Net.WebClient();
      var response= wc.DownloadString("http://catfactsapi.appspot.com/api/facts");
      var cat = JsonConvert.Deserialize<Cat>(response); 
      // Access facts
      if(cat !=null && car.Facts!= null)
      {
           foreach(var fact in car.Facts)
           {
           }
      }
