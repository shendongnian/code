    for(var i = 0; i < array.Length; i++)
    {
        if(value == array[i])
        {
            Console.WriteLine("The value is in the array");
            return;
        }
    }
    
    Console.WriteLine("The value is not in the array");
