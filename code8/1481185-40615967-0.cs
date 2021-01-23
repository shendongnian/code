    class Program
    {
        internal class MyValues
        {
            internal string SomeString { get; set; }
            internal int SomeInt { get; set; }
            internal bool SomeBool { get; set; }
        }
        static void Main(string[] args)
        {
            var mv = new MyValues() { SomeString = "asd", SomeInt = 123, SomeBool = false };
            Console.WriteLine(funcVars(mv));
            Console.ReadLine();
        }
        public static string funcVars(MyValues values)
        {
            string strVars =
                String.Join(", ", new[]
                {
                    nameof(values.SomeString), values.SomeString,
                    nameof(values.SomeInt), values.SomeInt.ToString(),
                    nameof(values.SomeBool), values.SomeBool.ToString()
                });
            return strVars;
        }
    }
