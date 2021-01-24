     using (StreamReader sr = new StreamReader(stream))
     {
         {
             VarrileKeeper.s = sr.ReadToEnd();
             //Console.WriteLine(VarrileKeeper.s);
              if (VarrileKeeper.s.ToString().Contains("ice"))
              {
                  VarrileKeeper.s = VarrileKeeper.s.Replace("ice",System.Environment.NewLine);
              }
              sr.Close();
          }
    }
