    using Microsoft.VisualBasic.FileIO;
    
    var path = @"C:\Person.csv"; // Habeeb, "Dubai Media City, Dubai"
    using (TextFieldParser csvParser = new TextFieldParser(path))
    {
     csvParser.CommentTokens = new string[] { "#" };
     csvParser.SetDelimiters(new string[] { "," });
     csvParser.HasFieldsEnclosedInQuotes = true;
    
     // Skip the row with the column names
     csvParser.ReadLine();
    
     while (!csvParser.EndOfData)
     {
      // Read current line fields, pointer moves to the next line.
      string[] fields = csvParser.ReadFields();
      string Name = fields[0];
      string Address = fields[1];
     }
    }
