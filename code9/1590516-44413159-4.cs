    public class Person : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Person's address is {0}", ShippingAddress.ToString());
        }
    }
    public class Company : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Company's is {0}", ShippingAddress.ToString());
        }
    }
    public class Address
    {
        public string ToString()
        {
            return string.Format(" Street: {0}, {1}, {2}, {3}, post code{4}, {5}", StreetAddress, City, State, PostalCode, Country);           
        }
    }
