        private static void AddToXmlTemplate(Template tmp, string _config)
        {
            string configFile = _config + "configuredTemplate.xml";
            using (FileStream fs = new FileStream(configFile, FileMode.OpenOrCreate))
            {
                if (!File.Exists(configFile))
                {
                    XDocument xD = new XDocument();
                    xD.Add(new XElement("Store",
                        new XElement("template",
                        new XElement("filePath", tmp.TempPath),
                        new XElement("Name", tmp.TempName),
                        new XElement("description", tmp.TempDesc))));
                    xD.Save(fs);
                    fs.Flush();
                }
                else
                {
                    XDocument xD = XDocument.Load(fs);
                    XElement root = xD.Element("Store");
                    IEnumerable<XElement> rows = root.Descendants("template");
                    XElement last = rows.Last();
                    last.AddAfterSelf(
                        new XElement("template"),
                        new XElement("filePath", tmp.TempPath),
                        new XElement("Name", tmp.TempName),
                        new XElement("description", tmp.TempDesc));
                    xD.Save(fs);
                    fs.Flush();
                }
            }
        }
