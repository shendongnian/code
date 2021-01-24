    class AlleTicketsViewModel : Screen
    {
        private static readonly ITicketManager mgr = new TicketManager();
        public List<Ticket> Tickets { get; } new List<Ticket>();
        public AlleTicketsViewModel()
        {
            Tickets = mgr.GetTickets().ToList();
        }
    }
