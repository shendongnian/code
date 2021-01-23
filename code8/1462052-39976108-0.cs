    class StrangeEntity {
      [Column(Order=0), Key]
      public int Foo { get; set; }
      [Column(Order=1), Key]
      public string Bar { get; set; }
      [Column(Order=2), Key]
      public bool Baz { get; set; }
    }
