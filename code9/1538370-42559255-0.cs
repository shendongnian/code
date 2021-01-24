        private void getVariablesInProcessFile()
        {
            var xdoc = XDocument.Load(patches.ProcessFilePatch);
            var xmlns = XNamespace.Get("http://schema.metastorm.com/Metastorm.Common.Markup");
           var dane = xdoc.Descendants(xmlns + "Object").Where(x => CheckAttributes(x, xmlns)).ToArray();
            IEnumerable<string> valuesE = from x in dane.Descendants(xmlns + "Object")
                                           where x.Attribute(xmlns + "Type").Value.ToString().EndsWith("MboField}")
                                           select x.Attribute(xmlns + "Name").Value.ToString();
            VariablesInProcessFile = valuesE.ToList();
        }
        private bool CheckAttributes(XElement x, XNamespace xmlns)
        {
            var wynik = x.Attribute(xmlns + "Name");
            return wynik != null && (wynik.Value == patches.MapName + "Data" || wynik.Value == patches.altMapName + "Data");
        }
