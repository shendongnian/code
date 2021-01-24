        // InnerException: System.InvalidOperationException
        // Message="Types 'Question42409171.XMLStructure.Project.Package.NameElement' and 'Question42409171.XMLStructure.Project.NameElement' both use the XML type name, 'NameElement', from namespace ''. Use XML attributes to specify a unique XML name and/or namespace for the type."
    The solution is to eliminate the duplicates and retain one single definition:
        // Fixed - removed duplicates.
        // InnerException: System.InvalidOperationException
        // Message="Types 'Question42409171.XMLStructure.Project.Package.NameElement' and 'Question42409171.XMLStructure.Project.NameElement' both use the XML type name, 'NameElement', from namespace ''. Use XML attributes to specify a unique XML name and/or namespace for the type."
        public class NameElement 
        {
            // Fixed
            // This was marked as an element but should be an attribute
            [XmlAttribute("name")]
            public string name;
            public NameElement()
            {
                name = "";
            }
        }
