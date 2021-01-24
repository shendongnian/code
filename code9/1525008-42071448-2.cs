    public class XmlCar {
        public static readonly Encoding Utf8Encoding = Encoding.UTF8;
        public static readonly XmlSerializer MenuSerializer = new XmlSerializer(typeof(Car));
        public static Car Load(string path) {
            using (var stream = new StreamReader(path, Utf8Encoding, false)) {
                using (var reader = new XmlTextReader(stream)) {
                    return (Car)MenuSerializer.Deserialize(reader);
                }
            }
        }
        public static void Save(string path, Car instance) {
            using (var stream = new StreamWriter(path, false, Utf8Encoding)) {
                using (var writer = new XmlTextWriter(stream)) {
                    MenuSerializer.Serialize(writer, instance);
                }
            }
        }
    }
