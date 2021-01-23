    int[] array = new int[4];
    
    for (int i = 0; i < array.Length; i = i + 1)
    { 
        //Input
        array[i] = int.Parse(Console.ReadLine());
    }
    if (array[1] == 0)
    {
       Console.WriteLine("Alert!");
    }
   
    
