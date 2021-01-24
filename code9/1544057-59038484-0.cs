    class ChannelBinding {
        [Indexed(Name = "CompositeKey", Order = 1, Unique = true)]
        public int Id { get; set; }
        [Indexed(Name = "CompositeKey", Order = 2, Unique = true)]
        public string ChannelId { get; set; }
    }
