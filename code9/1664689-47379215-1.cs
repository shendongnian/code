    public static void Main(string[] args)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("article.xml");
        XmlNodeList nodes = doc.DocumentElement.SelectNodes("//xref[@ref-type='bibr' and starts-with(@rid,'ref')]/parent::*");
        foreach(XmlNode x in nodes)
        {
            XmlNodeList temp = x.SelectNodes("//xref[@ref-type='bibr' and starts-with(@rid,'ref')]");
            //we only select those that have 3 or more references.
            if (temp.Count >= 3)
            {
                Console.WriteLine(x.InnerText);
            }
        }
        Console.ReadKey();
    }
