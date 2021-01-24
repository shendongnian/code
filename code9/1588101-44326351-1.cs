    static void Main(string[] args)
    {
        int[] intArgs = new int[args.Length];
        for (int i = 0; i < args.Length; i++)
        {
            if (!int.TryParse(args[i], out intArgs[i]))
            {
                Console.WriteLine($"All parameters must be integers. Could not convert {args[i]}");
                return;
            }
        }
    }
