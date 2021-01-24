        ...
        internal class Program
        {
            private static void Main()
            {
                string line = File.ReadAllText(
                    @"C:\Users\Eggii\Desktop\code\c# katse\GoodsPrices\GoodsPrices\bin\Debug\PriceOfSoldGoods.txt");
    
                string[] splitLines = line.Split(' ');
                for (int j = 6; j < line.Length; j += 8)
                {
                    Console.WriteLine(line[j]);
                }
            }
        }
