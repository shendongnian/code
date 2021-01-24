    public class Repository : IRepository
    {
        public Bill GetBillDayCount(Bill bill)
        {
            bill.DayCount = (bill.EndDate - bill.StartDate).Days;
            return bill;
        }
    }
