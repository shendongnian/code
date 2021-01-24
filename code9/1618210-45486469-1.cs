    public partial class Tripmetadata
    {
        public Tripmetadata()
        {
        }
        [Key]
        [Display(Name = "Trip ID")]
        public int Tripid { get; set; }
        [Display(Name = "Start Timestamp")]
        public long? Starttimestamp { get; set; }
        [Display(Name = "End Timestamp")]
        public long? Endtimestamp { get; set; }
        [Display(Name = "Duration")]
        public long? Duration { get; set; }
        [Display(Name = "Average Speed")]
        public decimal? AvgSpeed { get; set; }
        [Display(Name = "Distance")]
        public decimal? Distance { get; set; }
    }
