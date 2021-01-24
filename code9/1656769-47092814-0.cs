    public class Customer
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string CustID { get; }
        public Customer(string firstName,string lastName,string custID)
        {
            CustID = custID;
            FirstName=firstName;
            LastName=lastName;
        }
    }
