    Double number = -1; 
    value = Console.ReadLine();
    if (Double.TryParse(value, out number))
      Console.WriteLine(number);
    else
      Console.WriteLine("{0} is outside the range of a Double.",...
