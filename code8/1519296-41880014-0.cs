    namespace TestWebTuiAPI.Models
    {
         [DataContract]
         public class Request
         {
             [DataMember]
             public Trip Child{ get; set; }
         }
         [DataContract]
         public class Child
         {
             [DataMember]
             public CountryISO CountryISO { get; set; }
         }
         [DataContract]
         public class CountryISO
         {
             [DataMember]
             public List<string> country { get; set; }
         }
     }
