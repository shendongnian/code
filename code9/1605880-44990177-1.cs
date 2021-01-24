    using System;
    using System.IO;
    
    namespace CalcPrices
    {
        internal class Program
        {
            private static void Main()
            {
                string[] lines = File.ReadAllLines(
                    @"C:\Users\Eggii\Desktop\code\c# katse\GoodsPrices\GoodsPrices\bin\Debug\PriceOfSoldGoods.txt");
      
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] line = lines[i].Split(' ');
                    Console.WriteLine(line[6]);
                }
            }
        }
    }
