    public class MyJavaScriptSerializer : JavaScriptConverter
    {
      public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
      {
		 throw new NotImplementedException();
      }
   
      public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
      {
        var myData = obj as MyData;
   
        var result = new Dictionary<string, object>();
        if (myData != null)
        {
          result["val1"] = myData.Val1;
          result["val2"] = myData.Val2;
          if(myData.Val3 != 0)
            result["val3"] = myData.Val3;
   
          return result;
        }
   
        return new Dictionary<string, object>();
      }
   
      public override IEnumerable<Type> SupportedTypes =>
          new ReadOnlyCollection<Type>(new List<Type> { typeof(MyData) });
    }
