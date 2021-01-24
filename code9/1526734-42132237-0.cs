     public async Task GetPictureAsync()
     {
         GraphServiceClient graphClient = GetGraphServiceClient();
         var photo = await graphClient.Me.Photo.Content.Request().GetAsync();
         using (var fileStream = File.Create("C:\\temp\\photo.jpg"))
         {
             photo.Seek(0, SeekOrigin.Begin);
             photo.CopyTo(fileStream);
         }
     }
