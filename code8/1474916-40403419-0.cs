    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
        public bool OperationWardrobes(XDocument document)
        {
            if (document == null)
                return false;
            try
            {
                // no need for else here
                Person person = null;
                XmlSerializer serializer = new XmlSerializer(typeof(Person));
                using (var reader = document.CreateReader())
                {
                    person = serializer.Deserialize(reader);
                    // do stuff
                    return true;
                }
            }
            catch (Exception ex)
            {
                // log ex
                return false;
            }
        }
