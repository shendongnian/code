    public class CompanyLanguageEditViewModel
    {
        [DisplayName("Company")]
        [Required]
        public int CompanyId { get; set; }
        [DisplayName("Language")]
        [Required]
        public int LanguageId { get; set; }
        public bool IsDefault { get; set; }
        public IEnumerable<SelectListItem> Companies{ get; set; }
        public IEnumerable<SelectListItem> Languages { get; set; }
    }
