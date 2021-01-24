    using (FileStream bufferStream = new FileStream(filePath, FileMode.Open, 
                    FileAccess.Read, FileShare.ReadWrite))
    {
       bufferStream.Lock(0L, bufferStream.Length);
       using (StreamReader sr = new StreamReader(bufferStream))
       {
           string line;
           while ((line = sr.ReadLine()) != null)    // <--- Here I get the error
           {
             CustomMessageBox.Show(line);
           }
       }
       
       // dispose lock
       bufferStream.Unlock(0L, bufferStream.Length);
    }
