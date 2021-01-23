        public static ulong Power(ulong A, ulong n)
        {
            ulong result = n;
            for(ulong i = 0; i < A; i++)
            {
                result *= A;
            }
            return result;
        }
