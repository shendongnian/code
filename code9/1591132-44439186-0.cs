    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product();
            Console.WriteLine(p);
            Console.ReadLine();
        }
    }
    public class Product
    {
        private Boolean _active;
        public Boolean active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
            }
        }
        public override string ToString()
        {
            return active ? "Yes" : "No";
        }
    }
