    using System.Web.Script.Serialization;
    using System.Dynamic;
    var serializer = new JavaScriptSerializer();
    serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
    dynamic jsonObject = serializer.Deserialize(jsonString, typeof(Example));
