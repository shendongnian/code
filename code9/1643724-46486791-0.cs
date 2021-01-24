            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement BkToCstmrAcctRpt = doc.Descendants().Where(x => x.Name.LocalName == "BkToCstmrAcctRpt").FirstOrDefault();
                XNamespace ns = BkToCstmrAcctRpt.GetDefaultNamespace();
                XElement LastPgInd = BkToCstmrAcctRpt.Descendants(ns + "LastPgInd").FirstOrDefault();
            }
