    public class ClassDConverter : JsonConverter
    {
         public override object ReadJson(...)
         {
               // custom deserialization code here
         }
         public override bool CanConvert(Type objectType)
         {
              return typeof(ClassD).isAssignableFrom(objectType);
         }
         public override bool CanWrite
         {
             get { return false; }
         }
     }
