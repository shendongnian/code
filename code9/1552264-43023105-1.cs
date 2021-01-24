    if (choice.ToUpper() == "Q")
        break;
    
    {
      temperature = Convert.ToInt32(choice);
      if (temperature < 17 || temperature > 25)
      {
        Console.WriteLine("Temp is {0} and its too cold to take a bath", temperature);
        Console.WriteLine("Enter the temp again");
      }
      else
      {
        Console.WriteLine("Temp is MADE TO 20, thou it is {0}, its ok to bath", temperature);
        Console.WriteLine("Enter the temp");
        temperature = Convert.ToInt32(Console.ReadLine());
      }               
    }
