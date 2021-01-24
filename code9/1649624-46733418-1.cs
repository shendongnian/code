    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Set password: ");
            var password = ReadPassword(8, 'o');
            Console.WriteLine();
            Console.WriteLine($"Your password is: {password}");
            Console.ReadKey();
        }
        static string ReadPassword(int length, char c)
        {
            var left = Console.CursorLeft;
            var top = Console.CursorTop;
            var password = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                password.Append(Console.ReadKey().KeyChar);
                Console.SetCursorPosition(left + i, top);
                Console.Write(c);
            }
            return password.ToString();
        }
    }
