    List<Marks> Observing1 = new List<Marks>(); // List to store all available Marks objects from the CSV
    // Marks statusInt = new Marks(); <<<<<< Move into loop!
    // Loops through each lines in the CSV
    foreach (string line in System.IO.File.ReadAllLines(OutputFilePath.Text).Skip(1)) // .Skip(1) is for skipping header
    {
        var statusInt = new Marks();
        // here line stands for each line in the CSV file
        string[] InCsvLine = line.Split(',');
        statusInt.Index=int.Parse(valuesInCsvLine[0]); 
        statusInt.Age=int.Parse(valuesInCsvLine[1]);      
        statusInt.Mark0 = (InCsvLine[2] == "TRUE" ? true : false);
        statusInt.Mark1 = (InCsvLine[3] == "TRUE" ? true : false);
        statusInt.Mark2 = (InCsvLine[4] == "TRUE" ? true : false);
        statusInt.Mark3 = (InCsvLine[5] == "TRUE" ? true : false);
        // Add your result to the List!
        Observing1.Add(stsusInt);
    }
    
    // Now you can filter as you wish
    var filteredByAge = Observing1.Where( x => x.Age > 25 ).ToList();
    // Writing to a new File is left as assignment for OP
