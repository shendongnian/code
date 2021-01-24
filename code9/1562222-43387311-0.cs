     public char[] File_Reader()
     {
        string filepath = @"env.txt"; //Variable to hold string
        StreamReader sr = new StreamReader(filepath);
        string fileContentInString = sr.ReadToEnd();
        sr.Close();
        return fileContentInString.ToCharArray();
      }  
