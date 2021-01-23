     string input = @"C:\temp\testinput.txt";
     string output = @"C:\temp\testoutput.txt";
     using (var reader = new StreamReader(input))
     {
         using (var writer = new StreamWriter(output))
         {
             var line = reader.ReadLine();
             while (line != null)
             {
                 var value = float.Parse(line);
                 var result = value * 2;
                 writer.WriteLine(result);
                 line = reader.ReadLine();
             }
         }                
     }
