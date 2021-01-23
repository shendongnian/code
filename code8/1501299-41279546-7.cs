      string content;
      // Do not dispose explicitly, wrap into using instead  
      using (WebClient client = new WebClient()) {
        // Download string (text) 
        content = client.DownloadString(fileadress);
        // Write the text to file (override existing if it is)
        File.WriteAllText(filename, content);
        // Upload file
        // think on uploading the string - client.UploadString(ftpAdress, content);
        client.UploadFile(ftpAdress, filename); 
      }
      string[] lines = content.Split(separator, StringSplitOptions.RemoveEmptyEntries);
      mode = lines.FirstOrDefault();    // 1st line
      gameInfo = lines.Skip(1).ToArray();  // all the others
