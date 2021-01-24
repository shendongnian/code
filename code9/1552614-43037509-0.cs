        public void print_days()
        {
            foreach (string day in names_of_days)
            {
                foreach (char c in day.Skip(3))
                {
                    Console.Write(c);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
