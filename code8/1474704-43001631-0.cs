        private void ManipulateXml(OfficeOpenXml.Table.PivotTable.ExcelPivotTable pivotTable)
        {
            var pivotTableXml = pivotTable.PivotTableXml;
            var nsManager = new XmlNamespaceManager(pivotTableXml.NameTable);
            nsManager.AddNamespace("d", "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
            nsManager.AddNamespace("x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");
            var topNode = pivotTableXml.DocumentElement;
            var nodes = topNode.SelectNodes("d:pivotFields/d:pivotField[@axis=\"axisRow\"]", nsManager);
            if (nodes == null) return;
            topNode.SetAttribute("updatedVersion", "6");//this line is important!
            foreach (XmlElement node in nodes)
            {
                var element = pivotTableXml.CreateElement("extLst", nsManager.LookupNamespace("d"));
                var ext = pivotTableXml.CreateElement("ext", nsManager.LookupNamespace("d"));
                ext.SetAttribute("uri", "{2946ED86-A175-432a-8AC1-64E0C546D7DE}");
                ext.SetAttribute("xmlns:x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");
                var fdLabels = pivotTableXml.CreateElement("x14:pivotField", nsManager.LookupNamespace("x14"));
                fdLabels.SetAttribute("fillDownLabels", "1");
                ext.AppendChild(fdLabels);
                element.AppendChild(ext);
                node.AppendChild(element);
            }
        }
