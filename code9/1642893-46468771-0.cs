    [XmlRoot("ItemCollection")]
    public class ItemContainer
    {
        [XmlArray("Items")]
        [XmlArrayItem("Weapon", Type = typeof(Weapon))]
        [XmlArrayItem("Armor", Type = typeof(Armor))]
        public List<Item> items = new List<Item>();
    
        public static ItemContainer LoadItems(string itemPath)
        {
            TextAsset _xml = Resources.Load<TextAsset>(itemPath);
    
            XmlSerializer serializer = new XmlSerializer(typeof(ItemContainer));
    
            StringReader reader = new StringReader(_xml.text);
    
            ItemContainer items = serializer.Deserialize(reader) as ItemContainer;
    
            reader.Close();
    
            return items;
        }
    }
