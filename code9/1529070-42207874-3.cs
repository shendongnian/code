    public class Account {
        public Account(int accountNumber) { AccountNumber = accountNumber; }
        public int AccountNumber { get; private set; }
        public string Name { get;set; } 
        public string LastName { get;set; } 
        public string HouseNumber { get;set; }
        public string PostalCode { get;set; }
        public int Balance { get;set; }
        public int Min { get;set; }
    }
