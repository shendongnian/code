    var inputText = "hello-my-name is Anna_B and I'm 30_years-old";
    var length = 15;
    
    var expectedString = new StringBuilder();
    var splittedStrings = Split(inputText, length);
            
    foreach (var splittedString in splittedStrings)
    {
        expectedString.AppendLine(splittedString);
    }
    
    Console.WriteLine(expectedString);
