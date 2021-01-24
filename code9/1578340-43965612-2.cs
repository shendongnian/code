    using System;
    namespace hwapp 
    {
        public static class Program 
        {&#xD;
            public static void Main(string[] args)
            {
                Example c = new Example
                {
                    c.numero = 12,
                    c.titular = "João",
                    c.saldo = 102,
                }
        
                Console.WriteLine($"Número: {c.Numero}");
                Console.WriteLine($"Titular da conta: {c.Titular}");
                Console.WriteLine($"Salto: {c.Saldo}");
            }
        }
        public class Example 
        {
            public int Numero { get; set; }
            public string Titular { get; set; }
            public int Saldo { get; set; }
        }&#xD;
    }
