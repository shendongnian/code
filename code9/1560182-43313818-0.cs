    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace StackOverflow_DigitRecognition
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = @"
    ---   ---    |  |   |   -----
     /     _|    |  |___|   |___ 
     \    |      |      |       |
    --    ---    |      |   ____|
    |  |   |   -----
    |  |___|   |___ 
    |      |       |
    |      |   ____|".TrimStart('\n', '\r');
                var rawDigits = ParseRawInputForDigits(input);
                foreach(string rawDigit in rawDigits)
                {
                    int digit = ParseDigit(rawDigit);
                    Console.WriteLine(digit);
                }
                Console.ReadKey();
            }
            private static List<string> ParseRawInputForDigits(string input)
            {
                var lines = input.Split('\n');
                const int lineHeight = 4;
                var rawDigits = new List<string>();
                for (int i=0; i < lines.Count(); i+=lineHeight)
                {
                    var currentLines = lines.Skip(i).Take(lineHeight).ToList();
                    var currentRawDigits = ParseLineForDigits(currentLines);
                    rawDigits = rawDigits.Concat(currentRawDigits).ToList();
                }
                return rawDigits;
            }
            private static List<string> ParseLineForDigits(List<string> currentLines)
            {
                // standardize
                currentLines = currentLines.Select(l => l.TrimEnd('\r')).ToList();
                // get columns as strings
                char[,] matrix = MatrixOps.To2D(currentLines.Select(l => l.ToCharArray()).ToArray());
                matrix = MatrixOps.Transpose(matrix);
                var columnsToString = MatrixOps.ColumnsToString(matrix);
                // eliminate extra empty columns
                var filteredColumns = new List<string>();
                foreach(string column in columnsToString)
                {
                    if (filteredColumns.Count == 0 || column != "    " || filteredColumns.Last() != "    ") // ' ' * lineHeight
                    {
                        filteredColumns.Add(column);
                    }
                }
                // separate digits
                var digitColumns = filteredColumns.Split("    ");
                var digits = new List<string>();
                foreach (var digitColumnSet in digitColumns)
                {
                    matrix = MatrixOps.To2D(digitColumnSet.Select(l => l.ToCharArray()).ToArray());
                    matrix = MatrixOps.Transpose(matrix);
                    var rows = MatrixOps.ColumnsToString(matrix);
                    string digit = string.Join("\r\n", rows);
                    digits.Add(digit);
                }
                return digits;
            }
            private static int ParseDigit(string input)
            {
                var digitFromPattern = new Dictionary<string, int>
                {
                    {   @"
    |
    |
    |
    |".TrimStart('\n', '\r')
                        , 1
                    }
                    ,{   @"
    ---
     _|
    |  
    ---".TrimStart('\n', '\r')
                        , 2
                    }
                    ,{   @"
    ---
     / 
     \ 
    -- ".TrimStart('\n', '\r')
                        , 3
                    }
                    ,{   @"
    |   |
    |___|
        |
        |".TrimStart('\n', '\r')
                        , 4
                    }
                    ,{   @"
    -----
    |___ 
        |
    ____|".TrimStart('\n', '\r')
                        , 5
                    }
                };
                return digitFromPattern[input];
            }
        }
        public static class MatrixOps
        {
            public static char[,] Transpose(char[,] matrix)
            {
                int w = matrix.GetLength(0);
                int h = matrix.GetLength(1);
                var result = new char[h, w];
                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        result[j, i] = matrix[i, j];
                    }
                }
                return result;
            }
            public static T[,] To2D<T>(T[][] source)
            {
                try
                {
                    int FirstDim = source.Length;
                    int SecondDim = source.GroupBy(row => row.Length).Single().Key; // throws InvalidOperationException if source is not rectangular
                    var result = new T[FirstDim, SecondDim];
                    for (int i = 0; i < FirstDim; ++i)
                        for (int j = 0; j < SecondDim; ++j)
                            result[i, j] = source[i][j];
                    return result;
                }
                catch (InvalidOperationException)
                {
                    throw new InvalidOperationException("The given jagged array is not rectangular.");
                }
            }
            public static List<string> ColumnsToString(char[,] matrix)
            {
                var columnsToString = new List<string>();
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    columnsToString.Insert(i, "");
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        string column = columnsToString[i];
                        string element = matrix[i, j] + "";
                        column += element;
                        columnsToString[i] = column;
                    }
                }
                return columnsToString;
            }
        }
        public static class Extensions
        {
            public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, TSource splitOn, IEqualityComparer<TSource> comparer = null)
            {
                if (source == null)
                    throw new ArgumentNullException("source");
                return SplitIterator(source, splitOn, comparer);
            }
            private static IEnumerable<IEnumerable<TSource>> SplitIterator<TSource>(this IEnumerable<TSource> source, TSource splitOn, IEqualityComparer<TSource> comparer)
            {
                comparer = comparer ?? EqualityComparer<TSource>.Default;
                var current = new List<TSource>();
                foreach (var item in source)
                {
                    if (comparer.Equals(item, splitOn))
                    {
                        if (current.Count > 0)
                        {
                            yield return current;
                            current = new List<TSource>();
                        }
                    }
                    else
                    {
                        current.Add(item);
                    }
                }
                if (current.Count > 0)
                    yield return current;
            }
        }
    }
