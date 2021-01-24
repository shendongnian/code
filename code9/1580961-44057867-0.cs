    HttpClient client = new HttpClient();
    var downloadUri = new Uri("https://domainame/someblobcontent.zip");
    Task<HttpResponseMessage> response = null;
    try
     {
           using (response = client.GetAsync(downloadUri, HttpCompletionOption.ResponseHeadersRead))
                {
                    if(response.Result.IsSuccessStatusCode)
                    {
                        Console.WriteLine("uri is valid, got response code {0}", response.Result.StatusCode);
                    }
                    else
                    {
                        Console.WriteLine("uri is not valid, got response code {0}", response.Result.StatusCode);
                    }
                }
      }
      catch(Exception e)
      {
          Console.WriteLine(e.ToString());
      }
