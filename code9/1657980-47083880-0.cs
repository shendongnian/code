    var serializer = new JavaScriptSerializer();
    var myClassObject = serializer.Deserialize<MyClass>(json);
    var xmlSerializer = new XmlSerializer(typeof(MyClass));
    using (var sww = new StringWriter())
    {
        using (XmlWriter writer = XmlWriter.Create(sww))
        {
            xmlSerializer.Serialize(writer, myClassObject);
            var xmlDocument = sww.ToString(); // Your XML
        }
    }
