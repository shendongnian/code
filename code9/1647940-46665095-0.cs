    public class BookParam
    {
        [JsonProperty("ds_seatInfo")]
        public List<KeyValuePair<string, string>> SetInfos = new List<KeyValuePair<string, string>>();
        [JsonProperty("SCN_SCH_SEQ")]
        public string ScnSchSeq { get; set; }
        [JsonProperty("REQ_FG_CD")]
        public string ReqFgCd { get; set; }
        [JsonProperty("LOCK_APRV_KEY")]
        public string LockAprvKey { get; set; }
    }
