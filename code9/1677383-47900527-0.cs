    public class Asset
    {
        public string AssetId { get; set; }
        public string UtilId { get; set; }
        public string Id
        {
            get;
            set
            {
                if(Regex.Match(value, "^[A-Z][a-zA-Z]*$").Success)
                {
                    AssetId = value;
                }
                else
                {
                    UtilId = id;
                }
            }
        }
    }
