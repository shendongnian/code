        class Program
        {
            static void Main(string[] args)
            {
    
                Osoba ne = new Osoba();
                test t1 = new test();
    
                t1.dwa = "fgfg";
                t1.raz = "dfdfdfdf";
                ne.tehe = t1;
    
                XmlSerializer xsSubmit = new XmlSerializer(typeof(Osoba));
    
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("dfs", "http://schemas.microsoft.com/office/infopath/2003/dataFormSolution");
                ns.Add("pc", "http://schemas.microsoft.com/office/infopath/2007/PartnerControls");
                var xml = @"D:\dupa1.xml";
    
    
                using (var stream = new FileStream(xml, FileMode.Create))
                {
                    using (XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8))
                    {
                        xsSubmit.Serialize(writer, ne, ns);
                    }
                }
    
            }
        }
