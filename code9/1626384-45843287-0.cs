    public class ComputerDetailsViewModel
    {
        public int ComputerID {get; set;} // populate in the action directly
        public IEnumerable<MyApp.Models.ComputerDetail> Items {get; set;}
    }
