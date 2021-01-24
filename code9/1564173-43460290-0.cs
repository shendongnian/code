    static void Main ( string [ ] args )
    {
        List<Transaction> accounts = new List<Transaction>
        {
            new Transaction { ID = 1, Details =  "Withdrawn 100"} ,
            new Transaction { ID = 2, Details =  "Withdrawn 200"} ,
            new Transaction { ID = 3, Details =  "Deposited 100"} ,
        };
        var query = accounts.
                Where ( x => x.Details.Contains ( "Withdrawn" ) && Convert.ToDecimal ( x.Details.Replace ( "Withdrawn" , "" ).Trim () ) > 100 ).
                ToList ();
        ReadKey ();
    }
    public class Transaction
    {
        public int ID { get; set; }
        public string Details { get; set; }
    }
