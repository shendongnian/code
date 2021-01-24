    [ProtoContract]
    class User
    {
      [ProtoMember(1)]
      public int Id { get; set; }
    
      [ProtoMember(2)]
      public string Name { get; set; }
    }
    
    [ProtoContract]
    class Message
    {
      [ProtoMember(1)]
      public byte Type { get; set; }
    
      [ProtoMember(2)]
      public float Value { get; set; }
    
      [ProtoMember(3)]
      public User Sender { get; set; }
    }
