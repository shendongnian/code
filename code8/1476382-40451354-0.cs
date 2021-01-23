    int start;
    int end;
    int increment;
    int sum = 0;
    int count= 0;
    
    Console.WriteLine(" Enter the start number ");
    start = Int32.Parse(Console.ReadLine());
    
    Console.WriteLine(" Enter the end number ");
    end = Int32.Parse(Console.ReadLine());
    
    Console.WriteLine(" Enter the increment number ");
    increment = Int32.Parse(Console.ReadLine());
    
    for ( count = start; count <= end ; count += increment  )
    {
        sum += count; 
        Console.WriteLine(" Number is: " + count);
    
    }
    
    Console.WriteLine(" Sum is: " + sum);
    Console.ReadKey();
