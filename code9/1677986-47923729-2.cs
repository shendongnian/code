    string[] numbers = new string[10];
    for (int i = 0; i < numbers.Length; i++)
    {
       numbers[i] = "0";
    }
    int biggest = 0;
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = Console.ReadLine();
        if (numbers[i] == "0")
        {
            break;
        }
    }
    int a = 0;
    foreach (string item in numbers)
    {
       if(Int32.TryParse(item,out a))
       {
          if (biggest < a)
               biggest = a;
       }
    }
    Console.WriteLine(biggest);
    Console.Read();
