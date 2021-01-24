    try
       {
    var jsonData = "{your json"}";
    var content = new MultipartFormDataContent();
    
    content.Add(new StringContent(jsonData.ToString()), "jsonData");
    try
       {
         //Checking picture exists for upload or not using a bool variable
         if (isPicture)
           {
             content.Add(new StreamContent(_mediaFile.GetStream()), "\"file\"", $"\"{_mediaFile.Path}\"");
           }
         else
          {
             //If no picture for upload
             content.Add(new StreamContent(null), "file");
          }
       }
      catch (Exception exc)
       {
          System.Diagnostics.Debug.WriteLine("Exception:>" + exc);
       }
                                    
    var httpClient = new HttpClient();
    var response = await httpClient.PostAsync(new Uri("Your rest uri"), content);
     if (response.IsSuccessStatusCode)
     {
       //Do your stuff  
     } 
    }
    catch(Exception e)
     {
     System.Diagnostics.Debug.WriteLine("Exception:>" + e);
    }
