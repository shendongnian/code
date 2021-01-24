    DirectoryInfo location = new DirectoryInfo(SourceLocation);
    byte[] bytes = System.IO.File.ReadAllBytes(location.FullName);
    XmlDocument PkPassFile = new XmlDocument();
    MemoryStream memstream = new MemoryStream(bytes);
    PkPassFile.Load(memstream);
    string FullFileName = DestinationFolder+ @"\" + file.Name + ".pkpass";
    rdlFile.Save(FullFileName);
