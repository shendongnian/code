    class Answer
    {
        public static bool Exists(int[] ints, int k)
        {
            int index = Array.BinarySearch(ints, k);
            if (index > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            int[] ints = { -9, 14, 37, 102 };
            Console.WriteLine(Answer.Exists(ints, 14)); // true
            Console.WriteLine(Answer.Exists(ints, 4)); // false
        }
     
    }
