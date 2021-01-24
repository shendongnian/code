     public class mergeClass
    {
        public string TicketType { set; get; }
        public int Quantity { set; get; }
        public double Amount { set; get; }
        public mergeClass(string T, int Q, double A)
        {
            TicketType = T;
            Quantity = Q;
            Amount = A;
        }
    }
