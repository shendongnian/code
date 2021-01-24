    public void SumOfSubset(double a, int k)
            {
                if (k > 4) return;
                x[k] = 1;
                var count = x.Where(i => i == 1).Count();
                if (((a * (count - 1)) + w[k]) / count == m)
                {
                    for (int i = 0; i <= k; i++)
                    {
                        if (x[i] == 1)
                        {
                            Console.Write(w[i] + ",");
                        }
                    }
                    Console.WriteLine();
                 
                }
    
              
                    if (((a * (count - 1)) + w[k] + w[k + 1]) / (count + 1) <= m)
                    {
                        SumOfSubset(((a * (count - 1)) + w[k]) / count, k + 1);
                    }
                    if (((a * (count - 1)) + w[k + 1]) / count <= m)
                    {
                        x[k] = 0;
                        SumOfSubset(a, k + 1);
                    }
                
    
            }
