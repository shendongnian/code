    string[] numbers = new string[10];
    int biggest = 0;
    int a = 0;
    bool isNumber = true;
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = Console.ReadLine();
        isNumber = Int32.TryParse(numbers[i], out a);
        if (i == 0)// in case that the first number is negative
        {
            isNumber = Int32.TryParse(numbers[i], out biggest);
        }
        if (numbers[i] == "0" || !isNumber)
        {
           break;
        }
        else
        {
            if (biggest < a)
                biggest = a;
        }
     }
     Console.WriteLine(biggest);
     Console.Read();
