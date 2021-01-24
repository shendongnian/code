     long test = 81;
     
     Console.WriteLine(81);
     // C# 6.0+ string interpolating
     // if don't use C# 6.0, put it as formatting: 
     // Console.WriteLine("{0:X16}", GetHexNumber(test)); 
     Console.WriteLine($"{GetHexNumber(test):X16}");
