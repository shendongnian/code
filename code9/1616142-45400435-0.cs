    string line;
    // Read the file and display it line by line.
    System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.txt");
    while((line = file.ReadLine()) != null)
    {
       List<string> ListOfParsedValues = line.Trim().Split(' ');
       if (ListOfParsedValues[0] == "[PRG]")
       {
          string desiredValue = //ListOfParsedValues.Last() ... or whatever you want here
       }
    }
    file.Close();
