    protected List<string> GetEmbeddedResourceResxDocumentPaths(Project project)
    {
        XDocument xmldoc = XDocument.Load(project.FilePath);
        XNamespace msbuild = "http://schemas.microsoft.com/developer/msbuild/2003";
        var resxFiles = new List<string>();
        foreach (var resource in xmldoc.Descendants(msbuild + "EmbeddedResource"))
        {
            string includePath = resource.Attribute("Include").Value;
            var includeExtension = Path.GetExtension(includePath);
            if (0 == string.Compare(includeExtension, RESX_FILE_EXTENSION, StringComparison.OrdinalIgnoreCase))
            {
                var outputTag = resource.Elements(msbuild + LAST_GENERATED_TAG).FirstOrDefault();
                if (null != outputTag)
                {
                    resxFiles.Add(outputTag.Value);
                }
            }
        }
        return resxFiles;
    }
