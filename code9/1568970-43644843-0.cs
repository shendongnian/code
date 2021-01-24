     string XmlString = "<ARandomXmlRoot> XML HERE </ARandomXmlRoot>";
                XmlAttributeOverrides overrides = new XmlAttributeOverrides();
    
                //Select fields I DON'T WANT TO SERIALIZE because they throw exception
                string[] properties = (new MySerializableClass())
                    .GetType().GetProperties()
                    .Where(p => !Attribute.IsDefined(p, typeof(IWantToSerializeThisAttribute)))
                    .Select(p => p.Name);
    
                //Add an XmlIgnore attribute to them
                properties.ToList().ForEach(field => overrides.Add(typeof(MySerializableClass), field, new XmlAttributes() { XmlIgnore = true }));
    
                MySerializableClass doc = new MySerializableClass();
    
                XmlSerializer serializerObj = new XmlSerializer(typeof(MySerializableClass), overrides);
    			using (StringReader reader = new StringReader(xmlString))
    			{
    				doc = (MySerializableClass)serializerObj.Deserialize(reader);
    			};
           
