    class Program
        {
            static void Main(string[] args)
            {
                SetColor(RanngDe.Blue);
                Console.Clear();
                Console.ReadKey();
            }
            public static void SetColor(RanngDe R)
            {
                switch (R)
                {
                    case RanngDe.Blue:
                         Console.BackgroundColor = ConsoleColor.Blue;
                        break;
    
                        // other case statements
                }
            }
        }
        public enum RanngDe
        {
            Blue,
            White,
            Red,
            Green
        }
