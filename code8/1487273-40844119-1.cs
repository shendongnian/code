    string manifestFile = new WebClient().DownloadString(@"\\*\*.application");
    XDocument xdoc = XDocument.Parse(manifestFile);
    XNamespace nsSys = "urn:schemas-microsoft-com:asm.v1";
    Version versionNew = new Version(xdoc.Descendants(nsSys + "assemblyIdentity").First().Attribute("version").Value);
    int result = applicationDeplayment.CurrentVersion.CompareTo(versionNew);
    if (result < 0)
    {
       applicationDeplayment.UpdateAsync();
    }
