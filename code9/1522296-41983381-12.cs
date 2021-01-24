    public class FileMenu {
        public static readonly Encoding Utf8Encoding = Encoding.UTF8;
        public static readonly XmlSerializer MenuSerializer = new XmlSerializer(typeof(Menu));
        public static Menu Load(string path) {
            using (var stream = new StreamReader(path, Utf8Encoding, false)) {
                using (var reader = new XmlTextReader(stream)) {
                    return MenuSerializer.Deserialize(reader) as Menu;
                }
            }
        }
        public static void Save(string path, Menu instance) {
            using (var stream = new StreamWriter(path, false, Utf8Encoding)) {
                using (var writer = new XmlTextWriter(stream)) {
                    MenuSerializer.Serialize(writer, instance);
                }
            }
        }
    }
