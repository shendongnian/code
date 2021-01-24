    public class BookParam
    {
        [JsonProperty("ds_seatInfo")]
        public List<SeatInfo> DsSeatInfo = new List<SeatInfo>();
        [JsonProperty("SCN_SCH_SEQ")]
        public string ScnSchSeq { get; set; }
        [JsonProperty("REQ_FG_CD")]
        public string ReqFgCd { get; set; }
        [JsonProperty("LOCK_APRV_KEY")]
        public string LockAprvKey { get; set; }
    }
    public class SeatInfo()
    {
         [JsonProperty("SEAT_LOC_NO")]
         public string SeatLocNo { get; set; }
    }
