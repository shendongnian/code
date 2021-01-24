    // Loop till rows - 1
    for (int i = 0; i < rows; i++)
    {
        Console.WriteLine("Enter the size for the array in the " + i + " row:");
        size = int.Parse(Console.ReadLine());
        arr[i] = new int[size];
        int n = 0;
        while (n < size)
        {
           arr[i][n] = randNum.Next(Min, Max);
           n++;
        }
    }
