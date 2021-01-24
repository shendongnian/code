    public class Program
    {
        public static void Main(string[] args)
        {
            var x = (IEnumerator<double>)(new double[] {0}).AsEnumerable();
        }
    }
