    class Document {
        public DocumentItem[] DocumentItemList { get; set; }
    }
    
    class DocumentViewModel : Document{
        [JsonIgnore]
        public new DocumentItemViewModel[] DocumentItemList { get; set; }
    }
