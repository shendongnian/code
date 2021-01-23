    public class InformationSaveFile
    {   // A list to safe all info entries
        public List<Information> InformationList { get; set; }
        public InformationSaveFile()
        {
            InformationList = new List<Information>();
        }
        // you method to save data
        public static void SaveData(object obj, string filename)
        {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(filename);
            sr.Serialize(writer, obj);
            writer.Close();
        }
        // a method to Load the Data
        public static InformationSaveFile LoadData(string FileName)
        {
            using (var stream = File.OpenRead(FileName))        // File ist aus dem Namensraum System.IO
            {
                var serializer = new XmlSerializer(typeof(InformationSaveFile));
                InformationSaveFile w = serializer.Deserialize(stream) as InformationSaveFile;
                return w;
            }
        }
        
    }
