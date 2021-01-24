    public class Asset
    {
        private string id;
        public string AssetId { get; set; }
        public string UtilId { get; set; }
        public string Id
        {
            set
            {
                if (Regex.Match(value, "^[A-Z][a-zA-Z]*$").Success)
                {
                    this.id = value;
                }
                else
                {
                    UtilId = value;
                }
            }
            get
            {
                return id;
            }
        }
    }
