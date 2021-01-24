    public static string getText(string filePath) 
    {
         using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
         {
             using (TextReader tr = new StreamReader(fs))
             {
                 return tr.ReadToEnd();
             }
         }
    }
