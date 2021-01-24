        private static void PrintHexLine(int z, int size)
        {
            if (z >= size)
            {
                z = 2 * size - 2 - z;
            }
            int start = size - z - 1;
            int end = start + size + z;
            for (int x2 = 0; x2 < start; x2++)
            {
                Console.Write(" ");
            }
            for (int x2 = start; x2 < end; x2++)
            {
                Console.Write("* ");
                //Console.Write((x2 - start / 2) + " "); // position v1
                //Console.Write((x2 - (start + 1) / 2) + " "); // position v2
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
