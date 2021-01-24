    // The class where you keep the value for a single month...
    public class MonthAmount
    {
        public int Month {get;set;}
        public decimal Amount {get;set;}
    }
    ....
    // A List where each month of data will be added...
    List<MonthAmount> amountData = new List<MonthAmount>();
    while(reader.Read())
    {
        // Create the instance of MonthAmount for the current month..
        MonthAmount m = new MonthAmount()
        {
              Month = Convert.ToInt32(reader["month"]); 
              Amount = Convert.ToDecimal(reader["sum_amountpaid"]);
        }
        // Add it to the list...
        amountData.Add(m);
    }
    reader.Close();
    // Return the info to the caller....
    return amountData;
