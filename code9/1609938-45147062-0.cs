    public partial class TimeMarker
    {
        public Nullable<long> nrow { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<int> OrderNo { get; set; }
        public string MeetingID { get; set; }
        public string AgendaName { get; set; }
        public string ChiAgendaName { get; set; }
        public int AgendaCode { get; set; }
        public string AgendaTime { get; set; }
        public string SpeakerCode { get; set; }
        public Nullable<int> MarkerID { get; set; }
        public string AgendaRunningTime { get; set; }
        public Nullable<bool> AllLangFail { get; set; }
        public Nullable<bool> isLive { get; set; }
        public string PopUpMsg { get; set; }
        public Nullable<bool> HasVideo { get; set; }
        public int BookingInfoId { get; set; }
        [ForeignKey("BookingInfoId ")]
        public virtual BookingInfo BookingInfo { get; set; }
    }
