    public class Printing
    {
        TicketingSystem ticketingSystem;
        public Printing(TicketingSystem ticketingSystem) => 
                        this.ticketingSystem = ticketingSystem;
        public void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            Bitmap r3tsLogo = Properties.Resources.rt3slogo;
            Image image1 = r3tsLogo; //image 1 is r3tsLogo
            // remainder of your current code 
           .....
        }
    }
