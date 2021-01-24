    public class MyNumberArrayWithMethods
    {
        public int[] Numbers { get; set; }
        public Action<int, int> Writer { get; set; }
        
        //parametric constructor        
        public MyNumberArrayWithMethods(int length, Action<int, int> writer = null)
        {
            Numbers = new int[length];
            Writer = writer;
        }
        public void Generating(int lowerBound = 1, int upperBound = 50)
        {
            for (int c = 0; c < Number.Length; c++)
            {
                if (Number[c] == 0)
                {
                    Number[c] = GenerateNumber.Next(lowerBound, upperBound);
                    if(Writer != null)
                        Writer(c, Number[c])
                }
            }
        }
        public void Ordering()
        {
            Console.Clear();
            Array.Sort(Number);
            if(Writer != null)
                for (int i = 0; i < Number.Length; i++)
                    Writer(i, Number[i]);
        }
        //... all other methods that work with "Number" array should go here
    }
