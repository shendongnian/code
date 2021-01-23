    public async Task<ActionResult> MyAction(object param)
    {
        var raw = new DirectoryInfo(xconfig.Directory.FullName + "//raw");
        if (raw.Exists)
        {
            await Task.Run(() => 
            {
                var xmls = raw.GetFiles("*.xml");
                foreach (var xml in xmls)
                {
                    if(ProcessedXmlFiles != null)
                    {
                        if(!ProcessedXmlFiles.Contains(xml.Name))
                        {
                            ExportData(xml);
                            ProcessedXmlFiles.Add(xml.Name);
                        }
                    }
                }
            });
            // Do something
        }
        return View();
    }
