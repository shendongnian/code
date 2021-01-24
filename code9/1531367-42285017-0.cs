    public Car
    {
      public int Year{ get; set; }
      public String Make{ get; set; }
      
      [OnDeserialized]
      internal void OnDeserializedMethod(StreamingContext context)
      {
        if (Year > 2017 || Year < 1900)
          throw new InvalidOperationException("...or something else");
      }
    }
