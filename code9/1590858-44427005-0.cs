    public static string UpdateJobAction(string inputXml)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(inputXml);
            var xpnavigator = xmlDocument.CreateNavigator();
            foreach (XPathNavigator xpn in xpnavigator.Select("//JobPositionPostings/JobPositionPosting/JobAction"))
            {
                var value = xpn.Value; // to obtain the JobAction value
                xpn.SetValue("Add");
            }
            return xpnavigator.OuterXml;
        }
