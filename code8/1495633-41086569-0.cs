    int[] array = new int[4];
    
    for (int i = 0; i < array.Length; i = i + 1)
    { 
        //Input
        array[i] = int.Parse(Console.ReadLine());
        if (array[i] == 0) // use i instead of 1
        {
            Console.WriteLine("Alert!");
        }
     }
