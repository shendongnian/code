    public class MyObject
    {
         public string TextField1;
         public Mydata[] Comments;
         [JsonProperty(PropertyName = "id")]
         public string Id;
     }
    
     public class Mydata
     {
         public string Comment;
     }
