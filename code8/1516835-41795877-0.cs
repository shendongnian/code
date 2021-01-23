    public class Program
    {
        public static void Main()
        {
            MyClass cl = new MyClass();
            var fi = cl.GetType().GetField("field", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            fi.SetValue(cl, 10);
        }
    }
