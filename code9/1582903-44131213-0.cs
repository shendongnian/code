    public class Program
    {
        [Serializable]
        public class Tst
        {
            public string A { get; set; }
        }
        static void Main(string[] args)
        {
            var serializer = new XmlSerializer(typeof(Tst));
            var arr = new Tst[]
            {
                new Tst { A = "s1"},
                new Tst { A = "s2"},
            };
            
            using (var stream = new MemoryStream())
            {
                using (var archive = new System.IO.Compression.ZipArchive(stream, ZipArchiveMode.Create, true))
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        var documentName = "def.xml";
                        if (i == 0) documentName = "commonInformation.xml";
                        if (i == 1) documentName = "contactInformation.xml";
                        var entry = archive.CreateEntry(documentName, CompressionLevel.NoCompression);
                        using (var writer = new StreamWriter(entry.Open()))
                        {
                            serializer.Serialize(writer, arr[i]);
                        }
                    }
                }
            }
        }
    }
