    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace StackOverflow
    {
      class Program
      {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<int>> rows = new Dictionary<string, HashSet<int>>();
            // The file "read.txt" is being read 
            string[] lines = new string[] { "1", "2", "1 2"};  //File.ReadAllLines("read.txt");
            // In this section each line is being read and the spacing is removed 
            foreach (string s in lines)
            {
                string[] arr = s.Split(' '); // This line ables the program to differ between variables and numbers. 
                int[] array = new int[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    array[i] = Convert.ToInt32(arr[i]); // arr is now converted into a Int.
                    string key = "array" + i;
                    if (!rows.ContainsKey(key)) rows.Add(key, new HashSet<int>());
                    rows[key].Add(array[i]);
                }
            }
            foreach (string key in rows.Keys)
            {
                Console.WriteLine($"{key}: {String.Join(", ", rows[key])}");
            }
        }
      }
    }
