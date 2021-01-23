    class Program
        {
            static void Main(string[] args)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                string[] userinput = Console.ReadLine().Split(' ');
                int[] arr = new int[n];
                arr = Array.ConvertAll(userinput, Int32.Parse);
                CutTheStick(arr);
                Console.ReadKey();
            }
    
            private static void CutTheStick(int[] arr)
            {
                arr = arr.Where(s => s != 0).ToArray();
    
                if (arr.Length > 0)
                {
                    Console.WriteLine(arr.Length);
                    int k = arr.Min();
    
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] -= k;
                    }
    
                    CutTheStick(arr);
                }
            }
        }
