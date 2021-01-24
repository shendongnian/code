     using (StreamReader sr = new StreamReader(stream))
     {
         {
             VarrileKeeper.s = sr.ReadToEnd();
             //Console.WriteLine(VarrileKeeper.s);
              if (VarrileKeeper.s.ToString().Contains("ice"))
              {
                    VarrileKeeper.s+= Environment.NewLine;
              }
              sr.Close();
          }
    }
