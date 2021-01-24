    using System;
    using System.Data;
    using System.Diagnostics;
    
    
    namespace DataTable
    {
        public class Program
        {
            private const int _xLength = 15000;
            private const int _yLength = 1000;
            private static Random _random;
    
    
            public static void Main(string[] args)
            {
                double[,] array = new double[_xLength, _yLength];
                _random = new Random();
                for (int x = 0; x < _xLength; x++)
                {
                    for (int y = 0; y < _yLength; y++)
                    {
                        array[x, y] = _random.NextDouble();
                    }
                }
                Stopwatch stopwatch = Stopwatch.StartNew();
                OriginalPoster(array);
                stopwatch.Stop();
                TimeSpan originalCodeDuration = stopwatch.Elapsed;
                Console.WriteLine($"Original poster's code ran in {originalCodeDuration.TotalMilliseconds:0} msec.");
                array = null;
                GC.Collect();
                double[][] jaggedArray = new double[_xLength][];
                for (int x = 0; x < _xLength; x++)
                {
                    jaggedArray[x] = new double[_yLength];
                    for (int y = 0; y < _yLength; y++)
                    {
                        jaggedArray[x][y] = _random.NextDouble();
                    }
                }
                stopwatch.Restart();
                Mine(jaggedArray);
                stopwatch.Stop();
                TimeSpan myCodeDuration = stopwatch.Elapsed;
                Console.WriteLine($"My code ran in {myCodeDuration.TotalMilliseconds:0} msec.");
                double speedUp = originalCodeDuration.TotalMilliseconds / myCodeDuration.TotalMilliseconds;
                Console.WriteLine($"My code is {speedUp:0.00}x faster.");
            }
    
    
            private static void OriginalPoster(double[,] array)
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                int rowsCount = array.GetUpperBound(0) + 1;
                int colsCount = array.GetUpperBound(1) + 1;
                int i = 0;
                while (i < colsCount)
                {
                    dt.Columns.Add(); i++;
                }
                int ii = 0;
                while (ii < rowsCount)
                {
                    string[] a = GetRowFromArray(array, ii);
                    dt.Rows.Add(a);
                    ii++;
                }
            }
    
    
            private static string[] GetRowFromArray(double[,] array, int rowNumber)
            {
                int dim = array.GetUpperBound(1) + 1;
                string[] row = new string[dim];
                for (int i = 0; i < dim; i++)
                {
                    row[i] = array[rowNumber, i].ToString();
                }
                return row;
            }
    
    
            private static void Mine(double[][] Array)
            {
                System.Data.DataTable dataTable = new System.Data.DataTable();
                for (int y = 0; y < _yLength; y++)
                {
                    dataTable.Columns.Add();
                }
                for (int x = 0; x < _xLength; x++)
                {
                    dataTable.Rows.Add(Array[x]);
                }
            }
        }
    }
