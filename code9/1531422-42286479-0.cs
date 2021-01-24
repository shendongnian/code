    var serializer = new XmlSerializer(typeof(List<Category>), 
                                       new XmlRootAttribute("Categories"));
    using (var writer = new StringWriter())
    {
        serializer.Serialize(writer, cats);
        return writer.ToString();
    }
