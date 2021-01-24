    private void button4_Click(object sender, EventArgs e)
    {
      try
      {
        for (var i = 0; i < listBox2.Items.Count; i++)
        {
          var response = Code(listBox2.Items[i].ToString() + "\'");
          if (response.ToLower().Contains("mysql"))
          {
            Console.WriteLine("positive " + listBox2.Items[i].ToString());
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
    
    
    public static string Code(string url)
    {
      var webRequest = (HttpWebRequest)WebRequest.Create(url);
      webRequest.MaximumAutomaticRedirections = 4;
      webRequest.MaximumResponseHeadersLength = 4;
      webRequest.UserAgent = "Mozilla/5.0 (Taco2) Gecko/20100101";
      webRequest.Credentials = CredentialCache.DefaultCredentials;
    
      webRequest.Method = "GET";
    
      using (var webResponse = webRequest.GetResponse())
      {
        using (var sr = new StreamReader(webResponse.GetResponseStream(), System.Text.Encoding.UTF8))
        {
          return sr.ReadToEnd();
        }
      }
    }
