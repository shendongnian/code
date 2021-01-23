     XmlSerializer serializer = new XmlSerializer(typeof(Root));
     StringBuilder result = new StringBuilder();
     using (var writer = XmlWriter.Create(result))
     {
         serializer.Serialize(writer, root);  /// serialize              
     }
    
     using (var reader = new StringReader(result.ToString()))
     {
        var deserialized = (Root)serializer.Deserialize(reader); //// deserialize from string
     } 
