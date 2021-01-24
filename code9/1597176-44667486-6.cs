        [XmlRoot(ElementName = "allegati")]
        public class Allegati
        {
            ...
            public List<string> GetItemsWithKey(string key)
            {
                return Record.Select(x => x.Dato.FirstOrDefault(d => d.Nome == key)?.Text).ToList();
            }
        }
        var dt = XmlSerializerExtensions.DeserializeFromNonStandardXmlString<Allegati>(text);
        var a = dt.GetItemsWithKey("nomeFile");
        var b = dt.GetItemsWithKey("RelationID");
