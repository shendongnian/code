        public class Class1<T> where T : Temp
        {
            public IEnumerable<T> ItemSource
            {
                get;
                set;
            }
            public void WriteLine()
            {
                foreach (var item in ItemSource)
                {
                    Console.WriteLine(item.A);
                }
            }
        }
        public abstract class Temp
        {
            public abstract int A { get; set; }
        }
        public class TempClass : Temp
        {
            public override int A
            {
                get;
                set;
            }
            public TempClass(int t) { A = t; }
        }
