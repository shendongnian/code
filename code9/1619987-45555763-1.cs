    public class AddressCityComparer : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            return String.Compare(x.City, y.City);
        }
    }
