    using System;
    using System.Linq;
    
    public class Check{
        
        static void Main()
        {
            int[] candidates = {1, 2, 5, 9, 7, 11, 89};
            // This is the members of the "in" clause - the
            // the values you're trying to check against
            int[] targets = { 1, 5, 7, 89 };
            foreach (int candidate in candidates)
            {
                Console.WriteLine(
                    targets.Contains(candidate) ?
                    $"{candidate} is in targets" :
                    $"{candidate} is not in targets");
            }
        }
    }
