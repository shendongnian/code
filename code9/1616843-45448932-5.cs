    [DataContract]
    public class PagedResults<T>
    {
        /// <summary>
        /// The page number this page represents.
        /// </summary>
        /// 
        [DataMember]
        public int? OffSet { get; set; }
        /// <summary>
        /// The size of this page.
        /// </summary>
        [DataMember]
        public int? Limit { get; set; }
        //  /// <summary>
        //  /// The total number of pages available.
        //  /// </summary>
        //// public int TotalNumberOfPages { get; set; }
        /// <summary>
        /// The total number of records available.
        /// </summary>
        [DataMember]
        public int TotalNumberOfRecords { get; set; }
        /// <summary>
        /// The URL to the next page - if null, there are no more pages.
        /// </summary>
        [DataMember]
        public string NextPageUrl { get; set; }
        /// <summary>
        /// The URL to the Previous page - if null, there are no more pages.
        /// </summary>
        [DataMember]
        public string PrevPageUrl { get; set; }
        /// <summary>
        /// The URL to the Current page page - if null, there are no more pages.
        /// </summary>
        [DataMember]
        public string CurrentPageUrl { get; set; }
        /// <summary>
        /// The records this page represents.
        /// </summary>
        [XmlIgnore]
        [IgnoreDataMember]
        [JsonProperty]
        public object Results { get; set; }
        [XmlAnyElement("Results")]
        [DataMember(Name = "Results")]
        [JsonIgnore]
        public XElement ResultsXml
        {
            get
            {
                return JsonExtensions.SerializeExtraDataXElement("Results", Results);
            }
            set
            {
                Results = JsonExtensions.DeserializeExtraDataXElement("Results", value);
            }
        }
    }
