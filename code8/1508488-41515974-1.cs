    XElement Dir2Xml(string dir)
    {
        var dInfo = new DirectoryInfo(dir);
        var files = new XElement("files");
        foreach(var f in dInfo.GetFiles())
        {
            files.Add(new XElement("file", f.FullName)); //or use "f.Name" whichever you like
        }
        foreach (var d in dInfo.GetDirectories())
        {
            files.Add(new XElement("directory", new XAttribute("name", d.Name), Dir2Xml(d.FullName)));
        }
        return files;
    }
----
    var xmlstring = Dir2Xml(@"c:\temp").ToString();
