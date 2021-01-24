     static void Main(string[] args)
        {
            List<string> allLines = System.IO.File.ReadAllLines(@"C:\...").ToList();
        
            for (int i=0;i<=allLines.Length;++i)
            {
               if (allLines[i].Length > 483)
        {
            allLines[i] = allLines[i].Substring(0, 483) + "0";
        }
            }
        ...
        //write to new file
        }
