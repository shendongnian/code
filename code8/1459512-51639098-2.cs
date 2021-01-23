    public int Sum(params int[] values)
    {
         return values.Sum(); // Using linq here shows part of why this doesn't make sense.
    }
    
    var numbers = new int[] {1,2,3};
    
    Console.WriteLine(Sum(numbers));
