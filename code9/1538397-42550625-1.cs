     public IRandomAccessStream MakeFileStream()
      {
          var task = MakeFileStreamAsync();
          task.Wait();
          return task.Result;
      }
    
      public async Task<IRandomAccessStream> MakeFileStreamAsync()
      {
          StorageFolder sf = KnownFolders.DocumentsLibrary;
    
          var file = await sf.CreateFileAsync("daten.xml", CreationCollisionOption.OpenIfExists);
    
          using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
          {
              return stream;
          }
      }
