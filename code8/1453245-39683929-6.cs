    public class Presenter
    {
        [Required(ErrorMessage = "You must select at least one site.")]
        [Display(Name = "All site to have access too")]
        public int[] Sites { get; set; 
        public IEnumerable<Site> AvailableSites { get; set; }
    }
