    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = new int[] { 0, 0, 0, 0, 0};
            CalPermutations CP = new CalPermutations();
            CP.Run(array, 0);
        }
    }
    
    public class CalPermutations
    {
        // Prints all the permutations of array, starting at the specified index.
        public void Run(int[] array, int indexer)
        {
            if (indexer < 0 || indexer >= array.Length)
                return;
            
            // Keep [0, indexer] combination constant, change combination on right i.e. (indexer, Array.length).
            Run(array, indexer+1);
            
            // All the elements on right have finished, increment current element.
            array[indexer]++;
            
            // Check if current combination is STILL valid.
            if(array[indexer] <= array.Length)
            {
                // since current combination is still valid, display it, and execute the process again on the new combination.
                Display(array);
                Run(array, indexer);
            }
            else
            {
                // Since current element is out of range, reset it.
                array[indexer] = 1;
            }
        }
        
        // Prints all the elements in array.
        public void Display(int[] array)
        {
            foreach (int num in array)
                Console.Write(num);
            Console.WriteLine();
        }
    }
