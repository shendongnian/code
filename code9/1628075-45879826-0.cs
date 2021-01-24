    public class TransactionHandler
    {
       private static string numfatura = _transaction.TransDocument + _transaction.TransSerial + _transaction.TransDocNumber;
    
       public static string Numfatura
       { 
            get { return numfatura ; }
            set { numfatura = value; }
       }
    }
