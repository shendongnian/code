    var splitRegex = new Regex(@"\s*{");
    
    string input = "/Tests/ShowMessage { 'Text': 'foo' }";
    
    //second version of the input: 
    //string input = "/Tests/ShowMessage{ 'Text': 'foo' }";
    
    string[] splittedText = splitRegex.Split(input, 2);
    splittedText[1] = "{" + splittedText[1];
