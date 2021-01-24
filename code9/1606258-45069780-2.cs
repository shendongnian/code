    using (var parser = new ChoXmlReader("sample.xml").WithXPath("/UpdateDB/Transaction")
        .WithField("Table", xPath: "/Insert/Table")
        .WithField("szCustomerID", xPath: "/Insert/Set/szCustomerID")
        .WithField("szCustomerName", xPath: "/Insert/Set/szCustomerName")
        .WithField("szExternalID", xPath: "/Insert/Set/szExternalID", valueConverter: (v) => ((string)v).Split('@')[0])
        .WithField("szExternalDate", xPath: "/Insert/Set/szExternalID", valueConverter: (v) => ((string)v).Split('@')[1])
        )
    {
        using (var writer = new ChoCSVWriter("sample.csv").WithFirstLineHeader())
            writer.Write(parser.Where(r => r.Table == "CUSTOMER").Select(r => new { szCustomerID = r.szCustomerID, szCustomerName = r.szCustomerName, szExternalID = r.szExternalID, szExternalDate = r.szExternalDate }));
    }
