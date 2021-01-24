    public class Bill
    {
        public Image OpenClosedIcon
        {
            get
            {
                return IsOpen
                    ? new Bitmap(Properties.Resources.open_invoice)
                    : new Bitmap(Properties.Resources.closed_invoice);
            }
        }
        public bool IsOpen
        {
            get;
            set;
        }
        // The rest of your Bill class definition... 
    }
