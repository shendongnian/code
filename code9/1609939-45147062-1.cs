    public partial class BookingInfo
    {
        [Required]
        public string BookingID { get; set; }
        public string BookingDate { get; set; }
        public string MeetName { get; set; }
        public string ChiMeetName { get; set; }
        public string VideoSource_1500 { get; set; }        
        public string languages { get; set; }        
        public string AvailableLangs { get; set; }
        public Nullable<int> StatusMarkers { get; set; }
        public string MeetRoomID { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<int> nexturl { get; set; }
        public string StrBookingStartTime { get; set; }
        public string MeetomgStatus { get; set; }
        
        [InverseProperty("BookingInfo")]
        public virtual ICollection<TimeMarker> TimeMarkers { get; set; }
    }
