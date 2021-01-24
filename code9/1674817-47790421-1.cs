    public class Foo : BaseClass
    {
        private TicketType _ticketType;
        public TicketType TicketType 
        {
            get => _ticketType; 
            set => Set( ref _ticketType, value );
        }
    }
