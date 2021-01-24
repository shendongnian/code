    public class SomeCons
    {
        public SomeCons(string cons)
        {
        }
    }
    static void Main(string[] args)
    {
        object result = Activator.CreateInstance(typeof(SomeCons));
    }
