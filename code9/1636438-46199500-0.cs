      private static object lk = new object();
         lock (lk)
            {
       using (FileStream fs = new FileStream("C:\\New\\" +fileName,FileMode.Create, FileAccess.ReadWrite))
    using (StreamWriter str = new StreamWriter(fs))
    {
    str.Write(jsonFile);
    str.Dispose();
    str.Close();
     }
      }
