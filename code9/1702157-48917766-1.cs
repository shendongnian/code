    class Ticket
    {
        public DateTime PurchaseDate { get; set; }
        public override string ToString()
        {
            return PurchaseDate.ToShortDateString();
        }
    }
    public static bool BoughtBetween(Ticket ticket, DateTime from, DateTime to)
    {
        return ticket?.PurchaseDate >= from && ticket.PurchaseDate <= to;
    }
