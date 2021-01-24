       // Create the file.
       using (FileStream fs = File.Create(path))
       {
          char[] value = "Text to add to the file\n".ToCharArray();
          fs.Write(Encoding.UTF8.GetBytes(value), 0, value.Length);
       }
               
