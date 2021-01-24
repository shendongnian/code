    int[] numbers = new int[10] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
    int a = 60;
    int result = -1;
    for (int i = 0; i < 10; i++)
    {
        if (numbers[i] == a)
        {
            result = i;
            break;
        }
    }
    if (result != -1)
    {
        Console.WriteLine("0-based location is " + result);
    }
    else
    {
        Console.WriteLine("Not found.");
    }
    Console.ReadLine();
