    public class SAPISetPermitInfoResponse
    {
        public string RC { get; set; }
        public string MessageText { get; set; }
    }
    public class RootObject
    {
        public SAPISetPermitInfoResponse SAPISetPermitInfo_response { get; set; }
    }
