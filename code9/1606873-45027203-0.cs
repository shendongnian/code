            string inputString = @"<result><error>error test</error><reporttype>2</reporttype><items><item><sku>0B0005</sku><style>0B0005.DAK.GREY</style><reason>Barcode cannot be moved to different SKUs</reason></item><item><sku>0B0005</sku><style>0B0005.DAK.GREY</style><reason>Barcode cannot be moved to different SKUs</reason></item></items></result>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(inputString);
            XmlSerializer serializer = new XmlSerializer(typeof(Result));
            object resultingMessage = null;
            using (StringReader rdr = new StringReader(doc.InnerXml)) {
                resultingMessage = (Result)serializer.Deserialize(rdr);
            }
