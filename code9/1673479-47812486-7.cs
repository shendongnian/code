    Colour.BindNumber(Colour.Red, 3);
    Colour.BindNumber(Colour.Blue, 6);
    Colour.BindNumber(Colour.Green, 7);
    
    var redTest = Colour.Red;
    var greenTest = Colour.Green;
    var blueTest = Colour.Blue;
    
    Console.WriteLine(redTest); //Red
    Console.WriteLine((int)redTest); //3
    
    Console.WriteLine(greenTest); //Green
    Console.WriteLine((int)greenTest); //7
    
    Console.WriteLine(blueTest); //Blue
    Console.WriteLine((int)blueTest); //6
    
    var red1 = Colour.Red;
    var red2 = Colour.Red;
    var green1 = Colour.Green;
    
    Console.WriteLine(red1 == red2); //True
    Console.WriteLine(Colour.Red == Colour.Red); //True
    Console.WriteLine(red1 == green1); //False
    Console.WriteLine(red1 == 3); //True
    Console.WriteLine(red1 == 5); //False
