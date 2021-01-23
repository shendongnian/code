     double input = 0.0;
    
     do { 
       Console.WriteLine("Please enter floating point value");
     }
     while (!double.TryParse(Console.ReadLine(), out input))
