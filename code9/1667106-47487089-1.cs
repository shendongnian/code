    SerializeCourses("CoursesList",courses);
    private static XDocument SerializeCourses(String rootElement, List<Course> courses)
    {
        XDocument doc = new XDocument();
    
        using (XmlWriter writer = doc.CreateWriter())
        {
            writer.WriteStartElement(rootElement);
                    
            foreach (Course course in courses)
                new XmlSerializer(typeof(Course)).Serialize(writer, course);
    
            writer.WriteEndElement();
        }
    
        return doc;
    }
