    namespace test_read_txt
    {
    class Program
    {
        static void Main(string[] args)
        {
            // A string is created for the 14 first element 
            Dictionary<string, int[]> rows = new Dictionary<string, int[]>();
            // The file "read.txt" is being read 
            string[] lines = File.ReadAllLines("read.txt");
            // In this section each line is being read and the spaceing is removed 
            int counter = 0;
            foreach (string s in lines)
            {
                //Console.WriteLine(s);
                string[] arr = s.Split(' '); // This line ables the program to differ between variables and numbers. 
                
                int[] array = new int[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    array[i] = Convert.ToInt32(arr[i]); // arr is now converted into a Int.
                }
                string key = "array_" + counter++;
                rows.Add(key, array);
                //ShowArray(array);
            }
            foreach (string key in rows.Keys)
            {
                Console.WriteLine($"{key}: {String.Join(" ", rows[key])}");
            }
            Console.ReadLine();
        }
        public static void ShowArray(int[] arr) {
            foreach (var item in arr) {
                Console.Write(item + "-");
            }
            Console.WriteLine();
        }
    }
