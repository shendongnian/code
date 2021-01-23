    using System;
    using System.Text;
    
    public class SortProblem
    {
        public static void Main()
        {
            Sort();
        }
    
        private static void Sort()
        {
            StringBuilder sb = new StringBuilder(); 
    
            var array = new[]
            {
                10, 10, 5, 2, 2, 5, 6, 7, 8, 15, 4, 4, 4, 2, 3, 5, 5, 36, 32, 623, 7, 475, 7, 2, 2, 44, 5, 6, 7, 71, 2
            };
    
            for (int i = 0; i < array.Length; ++i)
            {
                int max = i;
    
                for (int j = i + 1; j < array.Length; ++j)
                    if (array[max] < array[j])
                        max = j;
    
                sb.Append(max);
                sb.Append(" ");
    
                int temp = array[i];
                array[i] = array[max];
                array[max] = temp;
            }
    
            Console.WriteLine(sb.Remove(sb.Length - 1, 1).ToString());
            Console.WriteLine(string.Join(" ", array));
        }
    }
