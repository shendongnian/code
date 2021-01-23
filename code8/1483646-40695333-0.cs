            int[] myInts = { 123, 210, 111 };
            string[] result = myInts.Select(x => x.ToString()).ToArray();
            int k = 0;
            for (int i = 3; i > 0; i--)
            {
                while (k < 3)
                {
                    Console.Write(result[k].Substring(i - 1, 1));
                    k++;
                }
                k = 0;
                Console.WriteLine();
            }
