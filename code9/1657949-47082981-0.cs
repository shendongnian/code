    string[] names = assembly.GetManifestResourceNames();
    foreach (var name in names.Where(x => x.EndsWith("xsd")).ToList())
    {
        var info = assembly.GetManifestResourceInfo(name);
        if (info != null)
        {
            var fileName = info.FileName;
            // Do your stuff that needs filename here.
        }
    }
