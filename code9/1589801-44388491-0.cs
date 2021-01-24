    public class SerializeDeserialize
        {
            [XmlRoot(ElementName = "ArraofElements")]
            public class ArraofElements
            {
                private List<Element> elm = new List<Element>();
    
                [XmlElement("Module")]
                public List<Element> Elm
                {
                    get { return elm; }
                    set { elm = value; }
                }
            }
    
            public class Element
            {
                [XmlElement("ID")]
                public int id { get; set; }
    
                [XmlElement("Value")]
                public string value { get; set; }
            }
    
            ArraofElements dnl = new ArraofElements();
    
            public void Serialize(object sender, EventArgs e)
            {
                for (int i = 0; i < 10; i++)
                {
                    var temp = dnl.Elm.FirstOrDefault(x => x.id == i);
                    if (temp == null)
                        temp = new Element();
    
                    temp.id = i;
                    temp.value = "Element " + i;
    
                    dnl.Elm.Add(temp);
                }
    
                try
                {
                    // to Save columnorders to the file
                    var serializer = new XmlSerializer(typeof(ArraofElements));
                    var ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
    
    
                    using (TextWriter writer = new StreamWriter(@"your path"))
                    {
                        serializer.Serialize(writer, dnl, ns);
                    }
    
                }
                catch { }
            }
    
            public void Deserialize(object sender, EventArgs e)
            {
                try
                {
                    if (File.Exists(@"your path"))
                    {
    
                        var deserializer = new XmlSerializer(typeof(ArraofElements));
                        using (TextReader reader = new StreamReader(@"your path"))
                        {
                            dnl = (ArraofElements)deserializer.Deserialize(reader);
                        }
    
                    }
                }
                catch
                {
                }
            }
        }
