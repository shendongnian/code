    public class Program
        {
            public static void Main(string[] args)
            {
                //Your code goes here
                int[] array = new int[] { 0, 0, 0, 0};
                CalPermutations CP = new CalPermutations();
                CP.Run(array, 0);
    
            }
        }
        
        public class CalPermutations
        {
            public void Run(int[] array, int indexer)
            {
                if (indexer < 0 || indexer >= array.Length)
                    return;
                else
                {
                    if (array[indexer] <= array.Length)
                        Run(array, indexer+1);
                    array[indexer]++;
                    if(array[indexer] <= array.Length)
                    {
                        Display(array);
                        Run(array, indexer);
                    }
                    else
                        array[indexer] = 1;
                }
            }
            
            public void Display(int[] array)
            {
                foreach (int num in array)
                    Console.Write(num);
                Console.WriteLine();
            }
        }
