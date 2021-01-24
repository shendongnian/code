    public static class XmlModelSerializer<TRoot>
    {
        static XmlSerializer alternateSerializerInstance;
        static XmlSerializer currentSerializerInstance;
        public static XmlSerializer AlternateSerializerInstance { get { return alternateSerializerInstance; } }
        public static XmlSerializer CurrentSerializerInstance { get { return currentSerializerInstance; } }
        static XmlModelSerializer()
        {
            XmlAttributes alternateAttributes = new XmlAttributes
            {
                XmlElements = { new XmlElementAttribute("bar") },
            };
            XmlAttributeOverrides alternateOverrides = new XmlAttributeOverrides();
            alternateOverrides.Add(typeof(XmlModel), "Foo", alternateAttributes);
            alternateSerializerInstance = new XmlSerializer(typeof(TRoot), alternateOverrides);
            XmlAttributes currentAttributes = new XmlAttributes
            {
                XmlArray = new XmlArrayAttribute("foo"),
                XmlArrayItems = { new XmlArrayItemAttribute("bar") },
            };
            XmlAttributeOverrides currentOverrides = new XmlAttributeOverrides();
            currentOverrides.Add(typeof(XmlModel), "Foo", currentAttributes);
            currentSerializerInstance = new XmlSerializer(typeof(TRoot), currentOverrides);
        }
    }
