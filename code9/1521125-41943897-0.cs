    var testString = "00123";
    var testDouble = double.Parse(testString);
    
    Console.WriteLine(testDouble.ToString());   //would return 123
    Console.WriteLine(testDouble.ToString("00000")); //would return 00123
    Console.WriteLine(testDouble.ToString("000000"));	//would return 000123
 
 
