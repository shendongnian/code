    [Table("Counter")]
        public partial class RequestCountViewModels
        {
            public long Id { get; set; }
            public string IP { get; set; }
            [ForeignKey("ReqId")]
            public virtual RequestsModel ParentMdl { get; set; }
            public int ReqId { get; set; }
            public DateTime Time { get; set; }
        }
