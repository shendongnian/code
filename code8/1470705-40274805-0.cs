    //Creating values for testing
    TableCell statusCell1 = new TableCell();
    statusCell1.Text = "blah/blah blah";
    string[] splitString = statusCell1.Text.Split('/');
    string resultingString = splitString[0];
    string resultingString2 = splitString[1];
    Console.WriteLine(resultingString);
    Console.WriteLine(resultingString2);
    
    //prints out: 
    //blah 
    //blah blah
