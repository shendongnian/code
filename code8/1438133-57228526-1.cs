        public static ulong Power(ulong A, ulong n)
        {
            ulong result = n;
            for(ulong i = 0; i < A; i++)
            {
                result *= A;
            }
            return result;
        }
        static void Sample()
        {
            Console.WriteLine("Result: " + Power(12, 62));
        }
