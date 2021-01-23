      using (WebClient client = new WebClient()) {
        var lines = client
          .DownloadString(fileadress)  
          .Split(separator, StringSplitOptions.RemoveEmptyEntries);
        mode = lines.FirstOrDefault();
        gameInfo = lines.Skip(1).ToArray();
      }
