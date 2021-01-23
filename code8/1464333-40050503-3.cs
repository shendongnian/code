            static void Main(string[] args)
        {
            BooleanSet set = new BooleanSet();
            set.Append(false);
            set.Append(false);
            set.Append(true);
            set.Append(false);
            set.Append(true);
            set.Append(false);
            set.Append(true);
            Console.WriteLine("Checking the stored values:");
            Console.WriteLine(set.ToString());
            Console.WriteLine();
            Console.WriteLine("Checking the stored values again:");
            Console.WriteLine(set.ToString());
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
