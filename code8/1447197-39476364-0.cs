    [Table("CP-VIP-Preview")]
        public class CP_VIP_Preview
        {
            [Key]
            [DisplayName("Occupancy Timeline")]
            [Required]
            public string occupancyTimeline { get; set; }
    
            
            public occupancyTimelineTypes occupancyTimelineType
            {
                get
                {
                    return Enum.Parse(occupancyTimelineTypes, occupancyTimeline);
    
                }
            }
        }
    
        public class Homefront : DbContext
        {
            public DbSet<CP_VIP_Preview> Data { get; set; }
        }
    
        public enum occupancyTimelineTypes : int
        {
            TwelveMonths = 12,
            FourteenMonths = 14,
            SixteenMonths = 16,
            EighteenMonths = 18
        }
    
        public static class MyExtensions
        {
            public static SelectList ToSelectList(this occupancyTimelineTypes enumObj)
            {
                var values = from occupancyTimeline e in Enum.GetValues(typeof(occupancyTimeline))
                             select new { Id = e, Name = string.Format("{0} Months", Convert.ToInt32(e)) };
                return new SelectList(values, "Id", "Name", enumObj);
            }
        }
