    static void Main(string[] args)
        {
            int[] theArray = null;
            bringArray(ref theArray);
            for (int i = 0; i < theArray.Length; i++)
            {
                Console.WriteLine(theArray[i] + " ");
            }
            Console.ReadLine();
        }
        static void bringArray(ref int[] arr)
        {
            arr = new int[4] { 18, 28, 38, 48 };
        }
