    public abstract class ExpenseBase 
    {
        public DateTime ExpenseDate { get; set; }
        public double Cost { get; set; }
    }
    public class FuelExpense : ExpenseBase
    {
        public  Boolean FilledUp { get; set; }
    }
    public class OtherExpense : ExpenseBase
    {
        public string SomeOtherProperty { get; set; }
    }
