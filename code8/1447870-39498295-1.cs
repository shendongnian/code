    string stringOne = "one";
    string stringTwo = "two";
    
    stringOne = stringOne + stringTwo;
    stringTwo = stringOne.Substring(0, (stringOne.Length - stringTwo.Length));
    stringOne = stringOne.Substring(stringTwo.Length);
    
    // Prints stringOne: two stringTwo: one
    Console.WriteLine("stringOne: {0} stringTwo: {1}", stringOne, stringTwo);
