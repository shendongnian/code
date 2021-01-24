     static void Main(string[] args)
     {
         List<char> ls = new List<char> { 'A', 'B', 'C', 'D', 'E' };
         for (int i = ls.Count; i < (ls.Count * ls.Count)+ls.Count ; i++) {
             var x = Permute(i, ls);
             for (int j = 0; j < x.Length; j++) {
                 Console.Write(x[j] + " ");
             }
             Console.WriteLine();
         }
         Console.ReadKey(true);
            
     }
