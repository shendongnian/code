    static void Main(string[] args)
    {
        double x;
        Console.WriteLine("Escreva o numero");
        x = int.Parse(Console.ReadLine());
        if(IsPrime(x))
            Console.WriteLine("eh primo", x);
        else
            Console.WriteLine("{0} nao eh primo", x);
        Console.ReadKey();
    }
    private static bool IsPrime(double x)
    {
        double raiz;
        int y, tot1 = 0, tot2, z, raiz2;
        if (x == 2 || x == 3 || x == 5)
            return true;
        if (x % 2 == 0 || x < 7)
            return false;
        bool result = false;
        raiz = Math.Truncate(Math.Sqrt(x));
        raiz2 = Convert.ToInt32(raiz);
        z = Convert.ToInt32(x);
        for (y = 3; y <= raiz2; y++)
        {
            tot1 = z / y;
            tot2 = z % y;
            if (tot2 == 0)
            {
                result = false;//return
                raiz2 = y;
            }
            else
                if (y >= raiz2)
            {
                result = true;//return
                y += raiz2;
            }
        }
        if (y <= raiz2)
            return false;
        return result;            
    }
