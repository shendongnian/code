    class Program
    {
        static void Main()
        {
            // Input string contain separators.
            string value1 = "word1:word2:word3:word4";
            char[] delimiter1 = new char[] { ':' };   // <-- Split on these
    
            // ... Use StringSplitOptions.None.
            string[] array1 = value1.Split(delimiter1,
                StringSplitOptions.None);
    
            foreach (string entry in array1)
            {
                Console.WriteLine(entry);
            }
    
            // ... Use StringSplitOptions.RemoveEmptyEntries.
            string[] array2 = value1.Split(delimiter1,
                StringSplitOptions.RemoveEmptyEntries);
    
            Console.WriteLine();
            foreach (string entry in array2)
            {
                Console.WriteLine(entry);
            }
        }
    }
