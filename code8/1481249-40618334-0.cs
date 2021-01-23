    string xml = @"<AnimalTypeList>
                        <Type>Tiger</Type>
                        <Type>Rabbit</Type>
                    </AnimalTypeList>";
    var serializer = new XmlSerializer(typeof(AnimalList));
    var result = (AnimalList)serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xml)));
    [XmlRoot("AnimalTypeList")]
    public class AnimalList
    {
        [XmlElement("Type")]
        public string[] Animals;
    }
