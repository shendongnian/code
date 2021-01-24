    // The list of words to delete ("stop words")
    var stopWords = new List<string> { "remove", "these", "words" };
    // The list of files to check - you can get this list in other ways
    var filesToCheck = new List<string>
    {
        @"f:\public\temp\temp1.txt",
        @"f:\public\temp\temp2.txt",
        @"f:\public\temp\temp3.txt"
    };
    // This list will contain all the unique words from all
    // the files, except the ones in the "stopWords" list
    var uniqueFilteredWords = new List<string>();
    // Loop through all our files
    foreach (var fileToCheck in filesToCheck)
    {
        // Read all the file text into a varaible
        var fileText = File.ReadAllText(fileToCheck);
        // Split the text into distinct words (splitting on null 
        // splits on all whitespace) and ignore empty lines
        var fileWords = fileText.Split(null)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Distinct();
        // Add all the words from the file, except the ones in 
        // your "stop list" and those that are already in the list
        uniqueFilteredWords.AddRange(fileWords.Except(stopWords)
            .Where(word => !uniqueFilteredWords.Contains(word)));
    }
