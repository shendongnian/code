    class Program
      {
        static void Main(string[] args)
        {
          string srcfile = @"C:\Workspace\tmp\TestSTuff\bank\transactions.txt";
          string transactionstr;
    
          using (FileStream fs = new FileStream(srcfile, FileMode.Open, FileAccess.Read))
          {
            byte[] buffer = new byte[fs.Length];
            int numtoread = (int)fs.Length;
            int numread = 0;
            while (numtoread > 0)
            {
              int n = fs.Read(buffer, numread, numtoread);
              if (n == 0)
                break;
              numread += n;
              numtoread -= n;
            }
            transactionstr = Encoding.Default.GetString(buffer); 
          }
    
          char[] newline = { '\r','\n' };
          char delim = ',';
          string[] transactionstrs = transactionstr.Split(newline);
    
          List<Transaction> transactions = new List<Transaction>();
          foreach (var t in transactionstrs)
          {
            try
            {
              string[] fields = t.Split(delim);
              DateTime.Parse(fields[1]);
              transactions.Add(new Transaction
              {
                AccountNumber = int.Parse(fields[0]),
                TransactionDate = DateTime.Parse(fields[1]),
                TransactionAmount = double.Parse(fields[2])
              });
            }
            catch
            {
              continue;
            }
          }
        }
      }
    
      public class Transaction
      {
        public int AccountNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public double TransactionAmount { get; set; }
      }
