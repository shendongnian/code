    class entityC
    {
      public Guid Id { get; set; }
      public Guid HistoryId { get; set; }
      [ForeignKey("HistoryId")]
      public entityA EntityA { get; set; }
    }
