    void Main()
    {
        var xDoc = new XDocument
        (
            new XElement("Parent",
                new XElement("TemplateID", "xxxxx"),
                new XElement("CaptionOptions",
                    new XElement("CaptionField",
                        new XElement("Field", "xxx"),
                        new XElement("Text", "xxx")
                    ),
                    new XElement("CaptionField",
                        new XElement("Field", "xxxx"),
                        new XElement("Text", "")
                    )
                )
            )
        );
        
        Console.WriteLine(xDoc.ToString());
        //To enclose the xml in a CDATA, you could use:
        var cData = new XCData(xDoc.ToString());
        Console.WriteLine(cData.ToString());
    }
