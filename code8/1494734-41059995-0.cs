    public class CustomResponse
    {
      public CustomData Data { get; set; }
    }
    [KnownType(typeof(UserEntity))]
    [KnownType(typeof(MessageErr))]
    [DataContract]
    public class CustomData
    {
      [DataMember]
      public object Data { get; set; }
    
      public CustomData(object obj) 
      {
         this.Data = obj;
      }
    }
