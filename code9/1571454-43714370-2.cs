        static void Test()
        {
            try
            {
                int[] values = { 1, 6, 4, 7, 9, 2, 5, 7, 2, 6, 5, 7, 8, 1, 3, 8, 2 };
                List<int> mode = new List<int>();
                mode = Mode(values);
                Console.WriteLine("Mode: {0}", String.Join(", ", mode));
                Console.ReadLine();
            }
            catch(Exception ex)
            {
            }
        }
