    public class InstallmentDetailsViewModel {
        public int? Id { get; set; }    
        [Display(Name = "Pay Date")]
        public List<DateTime> PayDates { get; set; }
        [Required]
        public List<double> InstallmentAmounts { get; set; }
    }
