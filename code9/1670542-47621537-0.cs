    using System;
    
    public class Test
    {
        static void Main()
        {
            string[] array =
            {
                "aabc", "aabaaa", "Abac", "abba", "acaaaa"
            };
            
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = array[i].PadRight(6, '0');
                Console.WriteLine(array[i]);
            }
        }
    }
