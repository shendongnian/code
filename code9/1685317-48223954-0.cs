    class Program
    {
        static void Main(string[] args)
        {
            string str = "I'm learning C#";
    
            var strArray = str.Split(' ');
    
            System.Array.Reverse(strArray);
    
            foreach (var item in strArray)
            {
                System.Console.Write(item + " ");
            }
    
            System.Console.WriteLine();
        }
    }
