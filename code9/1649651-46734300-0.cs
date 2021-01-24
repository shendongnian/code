    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        static class Program
        {
            static void Main(string[] args)
            {
                double[] closingPriceStock = { 39.32, 39.45, 39.27, 38.73, 37.99, 38.38, 39.53, 40.55, 40.78, 41.3, 41.35, 41.25, 41.1, 41.26, 41.48, 41.68, 41.77, 41.92, 42.12, 41.85, 41.54 };
                double[] closingPriceMarket = { 1972.18, 1988.87, 1987.66, 1940.51, 1867.61, 1893.21, 1970.89, 2035.73, 2079.61, 2096.92, 2102.44, 2091.54, 2083.39, 2086.05, 2084.07, 2104.18, 2077.57, 2083.56, 2099.84, 2093.32, 2098.04 };
    
                double[] closingPriceStockDailyChange = new double[closingPriceStock.Length - 1];
                double[] closingPriceMarketDailyChange = new double[closingPriceMarket.Length - 1];
    
                for (int i = 0; i < closingPriceStockDailyChange.Length; i++)
                {
                    closingPriceStockDailyChange[i] = (closingPriceStock[i + 1] - closingPriceStock[i]) / (100 * closingPriceStock[i]);
                    closingPriceMarketDailyChange[i] = (closingPriceMarket[i + 1] - closingPriceMarket[i]) / (100 * closingPriceMarket[i]);
                }
    
                double beta = Covariance(closingPriceStockDailyChange, closingPriceMarketDailyChange) / Variance(closingPriceMarketDailyChange);
    
                Console.WriteLine(beta);
    
                Console.Read();
            }
    
    
            public static double Variance(this IEnumerable<double> source)
            {
                int n = 0;
                double mean = 0;
                double M2 = 0;
    
                foreach (double x in source)
                {
                    n = n + 1;
                    double delta = x - mean;
                    mean = mean + delta / n;
                    M2 += delta * (x - mean);
                }
                return M2 / (n - 1);
            }
    
            public static double Covariance(this IEnumerable<double> source, IEnumerable<double> other)
            {
                int len = source.Count();
    
                double avgSource = source.Average();
                double avgOther = other.Average();
                double covariance = 0;
    
                for (int i = 0; i < len; i++)
                    covariance += (source.ElementAt(i) - avgSource) * (other.ElementAt(i) - avgOther);
    
                return covariance / len;
            }
    
        }
    
        
    }
