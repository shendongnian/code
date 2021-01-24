        public class Reservation
    {
        public IDialogContext Context { get; private set; }
        public Reservation(IDialogContext context )
        {
            this.Context = context;
        } 
