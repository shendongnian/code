    class Program
    {
        private int[] P;
        private int count, n;
        public int silnia(int n)
        {
            return (n == 1 || n == 0) ? 1 : silnia(n - 1) * n;
        }
        public void swap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }
        public int B(int m, int i)
        {
            if ((m % 2 == 0) && (m > 2))
            {
                if (i < (m - 1))
                    return i;
                else
                    return m - 2;
            }
            else
                return m - 1;
        }
        public void PERM(int m)
        {
            int[] I = new int[m + 1];
            for (int i = 1; i <= m; i++)
                I[i] = 1;
            int Mi = 1;
            while (count < silnia(m))
            {
                if (I[Mi] == Mi)
                {
                    if (I[Mi] == 1 && Mi == 1)
                    {
                        count++;
                        Console.Write("{0}:\t", count);
                        for (int i = 1; i <= n; i++)
                            Console.Write("{0} ", P[i]);
                        Console.WriteLine();
                    }
                    for (int i = 1; i <= Mi; i++)
                        I[i] = 1;
                    Mi++;
                }
                if (I[Mi] < Mi)
                {
                    int i = I[Mi];
                    swap(ref P[B(Mi, i)], ref P[Mi]);
                    I[Mi]++;
                    Mi = 1;
                }
            }
        }
        
        public void getData()
        {
            Console.WriteLine("Podaj ilość elementów: ");
            n = Int32.Parse(Console.ReadLine());
            P = new int[n + 1]; 
            for (int i = 1; i <= n; i++)
                P[i] = i;
            count = 0;
            PERM(n);
        }
        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.getData();
            Console.ReadKey();
        }
    }
