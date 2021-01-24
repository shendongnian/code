    string XMLFilePath = @"\\12.3.4.57\ABC\DEF\dir.xml"; // note the leading @ sign
    XmlDocument DirDoc = new XmlDocument();
    DirDoc.Load(XMLFilePath);
    string sourceFile = @"\\12.3.4.57\ABD\DEF\Test123 (26).pdf";  // note the leading @ sign
    string Folder = HttpContext.Current.Server.MapPath("~/SavedPDFs");
    string destPDFFile = string.Concat(Folder, "Test123 (26).pdf"); // I assume that the Folder variable will have the frontslash at the end
    System.IO.File.Copy(sourceFile, destPDFFile, true);
