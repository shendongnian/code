     static void Main(string[] args)
     {
        Complex c1 = new Complex(1.2,2.0)
        Complex c2 = new Complex(1,3.0)
       
        Complex c3 = c1.Sum(c2);
        Console.WriteLine(c3.Real);
        Console.WriteLine(c3.Imaginary);
        
     }
