    try
    {
         y.Player(double.Parse(Console.ReadLine()));
    }
    catch(FormatException)
    {
         //Input is not a double
    }
    catch(OverflowException)
    { 
         //Input is out of bounds for a double type 
    }
