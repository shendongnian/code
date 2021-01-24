        public int CreatorId { get; set; } //this field name will be column name
        [ForeignKey("StreamWorkerUser")]
        public StreamWorkerUser Creator { get; set; }
        public int EditorId { get; set; } //this field name will also be column name
        [ForeignKey("StreamWorkerUser")]
        public StreamWorkerUser Editor { get; set; }
