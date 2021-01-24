        static void Main(string[] args)
        {
            int[] theArray = bringArray();
            for (int i = 1; i < theArray.Length; i++)
            {
                Console.Write(theArray[i] + " ");
            }
        }
        static int[] bringArray()
        {
            return new int[4] { 18, 28, 38, 48 };
        }
