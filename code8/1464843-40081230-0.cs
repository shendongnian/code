    [Serializable]
    [XmlRoot]
    public class collection {
        private List<treeEntry> _entries = new List<treeEntry>();
        [XmlElement("item", typeof(item))]
        [XmlElement("folder", typeof(folder))]
        public List<treeEntry> entries {
            get { return _entries; }
        }
    }
    public abstract class treeEntry { }
    [Serializable]
    public class folder : treeEntry {
        private List<treeEntry> _entries = new List<treeEntry>();
        public folder() { }
        [XmlAttribute]
        public string name { get; set; }
        [XmlElement("item", typeof(item))]
        [XmlElement("folder", typeof(folder))]
        public List<treeEntry> entries {
            get { return _entries; }
        }
    }
    [Serializable]
    public class item : treeEntry { }
    public class mytest {
        public static void main() {
            collection col = new collection();
            col.entries.Add(new item());
            col.entries.Add(new item());
            var folder1 = new folder() { name = "someFolder" };
            folder1.entries.Add(new item());
            var folder2 = new folder() { name = "anotherFolder" };
            folder1.entries.Add(folder2);
            folder1.entries.Add(new item());
            folder2.entries.Add(new item());
            col.entries.Add(folder1);
            col.entries.Add(new folder());
            col.entries.Add(new item());
            XmlSerializer sers = new XmlSerializer(typeof(collection));
            //serialise
            using (StreamWriter sw = new StreamWriter("testoutput.xml", false, Encoding.UTF8)) {
                XmlWriter xw = new XmlTextWriter(sw);
                sers.Serialize(xw, col);
            }
            //deserialise
            FileStream fs = new FileStream("testoutput.xml", FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);
            collection newcol = (collection)sers.Deserialize(reader);
            //output to console
            sers.Serialize(Console.Out, newcol);
        }
    }
