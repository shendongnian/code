        class Calculator
        {
            public int Power(int n, int p)
            {
                if (n < 0)
                    throw new ArgumentOutOfRangeException(nameof(n), "n must be positive");
                if (p < 0)
                    throw new ArgumentOutOfRangeException(nameof(p), "p must be positive");
            
                return (int)Math.Pow(n, p);
            }
        }
