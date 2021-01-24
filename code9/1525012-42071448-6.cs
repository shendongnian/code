    public class XmlCar {
        public static readonly Encoding Utf8Encoding = Encoding.UTF8;
        public static readonly XmlSerializer CarSerializer = new XmlSerializer(typeof(Car));
        public static Car Load(string path) {
            using (var stream = new StreamReader(path, Utf8Encoding, false)) {
                using (var reader = XmlReader.Create(stream)) {
                    return (Car)CarSerializer.Deserialize(reader);
                }
            }
        }
        public static void Save(string path, Car instance) {
            using (var stream = new StreamWriter(path, false, Utf8Encoding)) {
                using (var writer = XmlWriter.Create(stream)) {
                    CarSerializer.Serialize(writer, instance);
                }
            }
        }
    }
