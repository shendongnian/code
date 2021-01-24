        public class Program
        {
            public static void Main(string[] args)
            {
                DerivedClass dc = new DerivedClass();
                dc.Display();
            }
        }
        public class BaseClass
        {
            private int value = 3;
        
            protected void DisplayValue()
            {
                Console.WriteLine(this.value);
            }
        }
        public class DerivedClass : BaseClass
        {
            public void Display()
            {
                DisplayValue();
            }
        }
