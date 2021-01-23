    public class Tehe
    {
        public string Raz { get; set; }
        public string Dwa { get; set; }
    }
    public class TeheRepository
    {
        private System.Xml.Linq.XDocument xmlDatas;
        public TeheRepository(string filePath)
        {
            xmlDatas = XDocument.Load(filePath);
        }
        public IEnumerable<Tehe> FindAll()
        {
            return xmlDatas.Elements().Elements().Select(tehe => 
            {
                Tehe t = new Tehe();
                t.Dwa = tehe.Elements().ElementAt(1).Value;
                t.Raz = tehe.Elements().ElementAt(0).Value;
                return t;
            });
        }
    }
