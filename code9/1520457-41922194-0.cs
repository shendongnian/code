    using System;
    class Program
    {
        static void Main(string[] args)
        {
            int deger1 = 0, deger2;
            deger2 = Convert.ToInt32(Console.ReadLine());
            for (int kivir =0; kivir <2; kivir++)
            {
                if (deger1 == 56)
                {
                    Console.WriteLine(Ekle(kivir, deger1));
                    deger2--;
                }
                else
                {
                    deger1 = 56;
                }
            }
        }
        static int Ekle(int deger1, int deger2)
        {
            return deger1 + deger2;
        }
    }
