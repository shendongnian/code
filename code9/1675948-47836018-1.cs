    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new[]
            {
                new [] {1, 2, 3, 4, 5},
                new [] {1, 2, 3, 4, 5},
                new [] {1, 2, 3, 4, 5},
                new [] {1, 2, 3, 4, 5},
            };
            var result = matrix.DeleteColums(new [] {0, 2, 4});
            foreach (var row in result)
            {
                foreach (var column in row)
                {
                    Console.Write(column);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
    static class MatrixHelper
    {
        public static T[][] DeleteColums<T>(this T[][] matrix, int[] columns)
        {
            var sorted = columns.Distinct().OrderBy(e => e).Concat(new [] { int.MaxValue }).ToArray();
            var target = new T[matrix.Length][];
            for (int row = 0; row < matrix.Length; row++)
            {
                var sourceRow = matrix[row];
                var targetRow = new T[sourceRow.Length - columns.Length];
                var sortedIndex = 0;
                for (int i = 0; i < sourceRow.Length; i++)
                {
                    if (i == sorted[sortedIndex])
                    {
                        sortedIndex++;
                        continue;
                    }
                    targetRow[i - sortedIndex] = sourceRow[i];
                }
                target[row] = targetRow;
            }
            return target;
        }
    }
