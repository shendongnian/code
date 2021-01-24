        private static void PrintHexLine(int z, int size)
        {
            if (z >= size)
            {
                z = 2 * size - 2 - z;
            }
            int start = size - z - 1;
            int end = start + size + z;
            for (int x = 0; x < start; x++)
            {
                Console.Write(" ");
            }
            for (int x = start; x < end; x++)
            {
                Console.Write("* ");
                //Console.Write((x - start / 2) + " "); // position v1
                //Console.Write((x - (start + 1) / 2) + " "); // position v2
            }
            Console.WriteLine();
        }
        public static void PrintHex(int size)
        {
            for (int z = 0; z < 2 * size - 1; z++)
            {
                PrintHexLine(z, size);
            }
        }
