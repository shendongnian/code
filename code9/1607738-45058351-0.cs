    void Main() {
      var sb = new StringBuilder();
      using(var tw = new StringWriter(sb))
      using(var writer = new Newtonsoft.Json.JsonTextWriter(tw)) {
        writer.WriteStartObject(); // {
        writer.WritePropertyName("data"); // data:
        writer.WriteStartArray(); // [
        writer.WriteStartArray(); // [
        writer.WriteValue("");    //   "",
        writer.WriteValue("Kia"); //   "Kia",
        writer.WriteValue("Nissan"); //"Nissan",
        // etc.
        writer.WriteEndArray();   // ],
        writer.WriteStartArray(); // [
        writer.WriteValue("2012");//   "2012",
        writer.WriteValue(10);    //   10,
        writer.WriteValue(11);    //   11,
        // etc.
        writer.WriteEndArray();   // ]
        writer.WriteEndArray();   // ]
        writer.WriteEndObject();  // }
      }
      Console.WriteLine(sb.ToString());
    }
