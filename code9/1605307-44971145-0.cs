    string line = string.Empty;
    using(System.IO.StreamReader file = new System.IO.StreamReader(@"c:\Path\To\BigFile.txt"))
    {
       while(!file.EndOfStream)
       {
          line = file.ReadLine();
          // Add here your frecuency logic
        }
    }
