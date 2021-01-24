     public class ClientDetailsViewModel
    {
        public ClientDetailsViewModel()
        {
            Jobs = new List<ClientJobListingViewModel>();
        }
        public ICollection<ClientJobListingViewModel> Jobs { get; set; }
    }
