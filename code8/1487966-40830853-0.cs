    static double[] SimpleMonte(double[][] a, int iter = 10000)
        {
            var n = a.GetLength(0);
            var p =
                a
                .Select(x => x.Select((_, i) => x.Take(i + 1).Sum()).ToArray())
                .ToArray();
            Random rand = new Random();
            long count = 0;
            double[] X = new double[n];
            int row = rand.Next(n);
            for (int i = 0; i < iter; i++)
            {
                var e = rand.NextDouble();
                count++;
                X[row]++;
                if (e < p[row][0])
                    row = 0;
                else
                    for (int j = 0; j < n - 1; j++)
                    {
                        if (p[row][j] <= e && e < p[row][j + 1])
                        {
                            row = j + 1;
                            break;
                        }
                    }
            }
            return X.Select(x => x / count).ToArray();
        }
