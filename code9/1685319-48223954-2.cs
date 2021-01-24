    class Program
    {
        static void Main()
        {
            string str = "I'm learning C#";
    
            var strArray = str.Split(' '); // splits a string into substrings
            System.Array.Reverse(strArray); // inverts the ordering of the array
    
            // Display reversed string
            foreach (var item in strArray)
            {
                System.Console.Write(item + " ");
            }
            System.Console.WriteLine();
        }
    }
