    class Test
    {
        static void Main(string[] args)
        {
            switch (args.Length)
            {
                case 1:
                    x = args[0]; // Invalid
                    break;
                case 0:
                    string x;
                    break;
            }
        }
    }
