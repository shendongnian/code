    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log, IBinder outputBinder)
    {
         var attribute new BlobAttribute($"{some dynamic path}/{some dynamic filename}", FileAccess.Write);
         using (var stream = await outputBinder.BindAsync<Stream>(attribute))
         {
              // do whatever you want with this stream here...
         }
    }
