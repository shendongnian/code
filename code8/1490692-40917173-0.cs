    public class HomePageViewModel
    {
        public IList<Farmer> Farmers { get; set; }
        public HomePageViewModel()
        {
            Farmers = new List<Farmer>();
        }
    }
