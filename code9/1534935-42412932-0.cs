    [DelimitedRecord("|")]
    public class CustomersVerticalBar
    {
        public string CustomerID;
        public string CompanyName;
        public string ContactName;
        public string ContactTitle;
        public string Address;
        public string City;
        public string Country;
    }
    class Program
    {
        private static string GetInsertSqlCust(object record)
        {
            CustomersVerticalBar obj = (CustomersVerticalBar)record;
            return String.Format("INSERT INTO Customers (Address, City, CompanyName, ContactName, ContactTitle, Country, CustomerID) " +
                    " VALUES ( '{0}' , '{1}' , '{2}' , '{3}' , '{4}' , '{5}' , '{6}'  ); ",
                    obj.Address,
                    obj.City,
                    obj.CompanyName,
                    obj.ContactName,
                    obj.ContactTitle,
                    obj.Country,
                    obj.CustomerID
                );
        }
        static void Main(string[] args)
        {
            SqlServerStorage storage = new SqlServerStorage(typeof(CustomersVerticalBar));
            storage.ServerName = "MYSERVER";
            storage.DatabaseName = "Northwind";
            // Comment this for Windows Auth
            storage.UserName = "shamp00";
            storage.UserPass = "whatever";
            storage.InsertSqlCallback = new InsertSqlHandler(GetInsertSqlCust);
            storage.InsertRecords(CommonEngine.ReadFile(typeof(CustomersVerticalBar), "infile.txt"));
            Console.ReadKey();
        }
    }
