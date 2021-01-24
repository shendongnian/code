    string s = string.Empty;
    using(WebClient client = new WebClient()) 
    {
      string s = client.DownloadString(url);
    }
    using (FileStream fs = new FileStream("test.html", FileMode.Create)) 
     { 
      using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8)) 
       { 
        w.WriteLine(s); 
       } 
      } 
