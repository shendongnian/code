    async Task<string> GetStringFromReaderAsync()
    {
      Streamreader sr = new StreamReader("filename.txt");
         Task<string> getStringTask = sr.ReadLineAsync("filepath");
        //Allow user to continue with some other work.
         DoFileLookup();
      string result = await sr.ReadLineAsync();
      return result.ToString();
    }
 
