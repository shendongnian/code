            XmlSerializer xsSubmit = new XmlSerializer(typeof(ValuationTransaction));
            var subReq = payloadPoco;
            var xml = "";
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    writer.WriteDocType("documentElement", null, null, "<!ENTITY AU \"Australia\"><!ENTITY NZ \"New Zealand\">");
                    xsSubmit.Serialize(writer, subReq);
                    xml = sww.ToString(); // Your XML
                    return xml;
                }
            }
