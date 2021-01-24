    class Program
    {
        static void Main(string[] args)
        {
            int value = -73651221;
            Console.WriteLine($"Int: {value}");
            var hex = value.ToString("X");
            Console.WriteLine($"Hex: {hex}");
            Console.WriteLine($"Int again: {int.Parse(hex, System.Globalization.NumberStyles.HexNumber)}");
            Console.Read();
        }
    }
