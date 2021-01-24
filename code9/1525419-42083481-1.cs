       static bool _isRedColor = true;
        static void Main(string[] args)
        {
            int n1, n2;
            
            // Top Triangle nested for loop
            for (n1 = 2; n1 <= 18; n1 += 2)
            {
                _isRedColor = true;
                for (n2 = 2; n2 <= n1; n2 += 2)
                {
                    SetConsoleColor();
                    Console.Write("{0} ", n2);
                    //n2++;
                }
                //n1++;
                Console.WriteLine();
            }
            // Bottom triangle nested for loop
            for (n1 = 16; n1 > 2; n1 -= 2)
            {
                _isRedColor = true;
                for (n2 = 2; n2 <= n1; n2 += 2)
                {
                    SetConsoleColor();
                    Console.Write("{0} ", n2);
                }
                Console.WriteLine();
            }
        }
        private static void SetConsoleColor()
        {
            if (_isRedColor)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                _isRedColor = !_isRedColor;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                _isRedColor = !_isRedColor;
            }
        }
