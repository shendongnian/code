    public int Sum(params double[] values)
    {
         return values.Sum(); // Using linq here shows part of why this doesn't make sense.
    }
    
    var numbers = new double[] {1.5, 2.0, 3.0}; // Double usually doesn't have precision issues with small whole numbers
    
    Console.WriteLine(Sum(numbers));
