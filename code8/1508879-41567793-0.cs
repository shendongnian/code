    public class NameValuesSection : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            var nameValues = new NameValuesCollection();
            foreach (XmlNode xmlNode in section.ChildNodes)
            {
                switch(xmlNode.Name)
                {
                    case "add":
                        List<string> values;
                        string key = xmlNode.Attributes["key"].Value;
                        string value = xmlNode.Attributes["value"].Value;
                        if (nameValues.TryGetValue(
                            key, 
                            out values))
                        {
                            values.Add(value);
                        }
                        else
                        {
                            values = new List<string>(new string[] { value });
                            nameValues.Add(key, values);
                        }
                        break;
                    default:
                        throw new ArgumentException("is not a valid node ", xmlNode.Name);
                }
            }
            return nameValues;
        }
    }
