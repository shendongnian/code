    public class CountrydetailsViewModel
    {
        [Required(Error Message = "..")]
        public int? SelectedCountry { get; set; }
        [Required(Error Message = "..")]
        public int? SelectedTown { get; set; }
        ....
        public IEnumerable<SelectListItem> CountryList{ get; set; }
        public IEnumerable<SelectListItem> TownList { get; set; }
    }
