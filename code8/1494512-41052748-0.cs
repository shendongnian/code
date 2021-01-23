    using(var textWriter = new StringWriter())
    using(var jsonWriter = new JsonTextWriter(textWriter))
    {
       jsonWriter.WriteStartObject();
       jsonWriter.WritePropertyName("success");
       jsonWriter.WriteValue(success);
       jsonWriter.WritePropertyName("message");
       jsonWriter.WriteValue(message);
       jsonWriter.WritePropertyName("data");
       jsonWriter.WriteRaw(jsonData);
       jsonWriter.WriteEndObject();
       var result = new ContentResult();
       result.Content = textWriter.ToString();
       result.ContentType = "application/json";
       return result;
    }
 
