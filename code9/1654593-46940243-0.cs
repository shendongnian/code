    static HttpClient client = new HttpClient ();
    public async Task DownloadImage(Object obj)
    {
        using(FormUrlEncodedContent formContent = GetFormContent(Obj)) {
           using(HttpResponseMessage Result = await 
               client.PostAsync("URL", formContent)
               .ConfigureAwait(false)){
                  byte[] Data = await temp.Content.ReadAsByteArrayAsync();
                  StaticClass.Images[Obj.ID] = ImageSource.FromStream(
                       () => new MemoryStream(Data));
            }
        }
        
    }
    
