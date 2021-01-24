    try
    {
      number = new int[Convert.ToInt32(words);
      Console.WriteLine("Please enter your numbers: ");
      for (i = 0; i < number.Length; ++i)
      {
        number[i] = Convert.ToInt32(Console.ReadLine());
        isInteger(words);
      }
    }
    catch (FormatException ex)
    {
      // Do something here ex is needed if you want to look at the exception
    }
