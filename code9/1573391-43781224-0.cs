    public class PostalCode
    {
         public string Value { get; private set; }
         public PostalCode(string value)
         {
             this.Value = value;
         }
         public static implicit operator string(PostalCode result)
         {
             return result.Value;
         }
     }
    var postCode = new PostalCode("WN11 2PZ");
    Console.Output(postCode);  // "WN11 2PZ"
