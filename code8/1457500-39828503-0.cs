    public class MyClass
    {
        public static Dictionary<string, int[]> Rows = new Dictionary<string, int[]>(); // initialize just in case
        public static void ReadText(string[] args)
        {
            Rows = new Dictionary<string, int[]>();
            string[] lines = File.ReadAllLines("txt.txt");
           ...
        }
    }
    public class AnotherClass
    {
        public void DoSomething()
        {
            // Make sure you have done MyClass.ReadText(args) beforehands
            // then you can call the int array
            int[] m_array_1 = MyClass.Rows["M_array_1"];
            int[] m_array_2 = MyClass.Rows["M_array_2"];
           // or
           foreach (string key in MyClass.Rows.Keys)
           {
               Console.WriteLine($"{key}: {String.Join(" ", rows[key])}");
           }
        }
    }
