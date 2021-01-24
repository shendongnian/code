        Console.WriteLine("Please insert the values that multiply x², x and the independent term respectively: ");
        float a = float.Parse(Console.ReadLine());
        float b = float.Parse(Console.ReadLine());
        float c = float.Parse(Console.ReadLine());
    
        double bhaskarap1 = (Math.Pow(b, 2)) + (- 4 * a * c);
        if (bhaskarap1 < 0)
        {
             Console.WriteLine("There are no real solutions.");
             return;
        }
        double raiz1 = (-b + Math.Sqrt(bhaskarap1)) / (2 * a);
        double raiz2= (-b - Math.Sqrt(bhaskarap1)) / (2 * a);
        Console.WriteLine(raiz1);
        Console.WriteLine(raiz2);
    }
