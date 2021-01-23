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
                        // see if we already had this key
                        if (nameValues.TryGetValue(
                            key, 
                            out values))
                        {
                            // yep, let's add another value to the list
                            values.Add(value);
                        }
                        else
                        {
                            // nope, let's create the list and add it to the dictionary
                            values = new List<string>(new string[] { value });
                            nameValues.Add(key, values);
                        }
                        break;
                    default:
                        // only add is supported now, not remove and clear
                        throw new ArgumentException("is not a valid node ", xmlNode.Name);
                }
            }
            return nameValues;
        }
    }
