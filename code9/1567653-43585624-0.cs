    public class CheckOutViewModel
    {
        public int ID { get; set; }
        public ApplicationUser CandidateId { get; set; }
        [Required]
        public string Image { get; set; }
    }
