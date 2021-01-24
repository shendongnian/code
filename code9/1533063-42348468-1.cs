     using (StreamReader sr = new StreamReader(filePath))
      {
        string line;
           while ((line = sr.ReadLine()) != null)
            {
            	Console.WriteLine(line);
                //Or do your work here.
            }
      }
