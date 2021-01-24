    public class MatchModel
    {
        [Key]
        public int MatchID { get; set; }
        [ForeignKey("LFMate")]
        public int? MatePropertyID { get; set; }
        [ForeignKey("LFHome")]
        public int? HomePropertyType { get; set; }
