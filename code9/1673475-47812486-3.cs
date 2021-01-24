    Colour.BindNumber(Colour.Red, 3);
    Colour.BindNumber(Colour.Blue, 6);
    Colour.BindNumber(Colour.Green, 7);
    
    var redTest = Colour.Red;
    var greenTest = Colour.Green;
    var blueTest = Colour.Blue;
    
    Console.WriteLine(redTest);
    Console.WriteLine((int)redTest);
    Console.WriteLine((string)redTest);
    
    //Red
    //3
    //Red
    Console.WriteLine(greenTest);
    Console.WriteLine((int)greenTest);
    Console.WriteLine((string)greenTest);
    
    //Green
    //7
    //Green
    Console.WriteLine(blueTest);
    Console.WriteLine((int)blueTest);
    Console.WriteLine((string)blueTest);
    
    //Blue
    //6
    //Blue
    Console.ReadKey();
