    public class ParamValues
    {
        public int MediaId {get; set; }
        // ...
    
        public ParamValues(int MediaId, int ProductsTypId, string id, string PreviousURL, HttpRequestBase Request, int? Width, int? Height, int? CampaignID)
        {
            this.MediaId = MediaId;
            // ...
        }
    }
