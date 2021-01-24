    public class LocalizationXml
    {
        [XmlAttribute]
        public int CodeLang { get; set; }
        [XmlAttribute]
        public string Label { get; set; }
    }
    public class RubricXml
    {
        [XmlAttribute]
        public string Code { get; set; }
        [XmlElement("Localization")]
        public List<LocalizationXml> Localizations { get; set; }
....
    static public object Deserialize(string filePath, Type objType)
		{
			object objToDeserialize = null;
			XmlTextReader xmlReader = null;
			XmlSerializer xmls = null;
			try
			{
				xmlReader = new XmlTextReader(filePath);
				xmls = new XmlSerializer(objType);
				objToDeserialize = xmls.Deserialize(xmlReader);
			}
			catch (Exception err)
			{
				BusinessLogger.Manage(err);
				return null;
			}
			finally
			{
				xmls = null;
				xmlReader.Close();
			}
			return objToDeserialize;
		}
