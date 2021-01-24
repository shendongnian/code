    class Program
    {
        static FloatIncreasing test = new FloatIncreasing();
        static void Main(string[] args) {
            test.ValueChangeEvent += Test_ValueChangeEvent;
            test.Value = 0;
            test.Value = 10;
            test.Value = 3;
            Console.ReadKey(true);
        }
        private static void Test_ValueChangeEvent(object sender, bool e)
        {
            Console.WriteLine(e ? "Value Decreased or Not Changed" : "Value increased");
        }
    }
