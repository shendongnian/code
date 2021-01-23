    using System;
    using System.Collections.Generic;
    
    public class Check{
        
        static void Main()
        {
            int[] candidates = {1, 2, 5, 9, 7, 11, 89};
            var targets = new HashSet<int> { 1, 5, 7, 89 };
            foreach (int candidate in candidates)
            {
                Console.WriteLine(
                    targets.Contains(candidate) ?
                    $"{candidate} is in targets" :
                    $"{candidate} is not in targets");
            }
        }
    }
