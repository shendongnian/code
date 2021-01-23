      string content;
      // Do not dispose explicitly, wrap into using instead  
      using (WebClient client = new WebClient()) {
        content = client.DownloadString(fileadress);
      }
      string[] lines = content.Split(separator, StringSplitOptions.RemoveEmptyEntries);
      string mode = lines.FirstOrDefault();    // 1st line
      gameInfo = lines.Skip(1).ToArray();  // all the others
