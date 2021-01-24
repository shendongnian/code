    // Write XML
    StringWriter sw = new StringWriter();
    ResultDT.WriteXml(sw, XmlWriteMode.WriteSchema);
    string OutputXML = sw.ToString();
    // now replace the Table Name
    OutputXML = OutputXML.Replace("<" + ResultDT.TableName + ">", "<" + "ExportTable" + ">");
    OutputXML = OutputXML.Replace("</" + ResultDT.TableName + ">", "</" + "ExportTable" + ">");
    OutputXML = OutputXML.Replace("MainDataTable=\"" + ResultDT.TableName + "\"", "MainDataTable=\"" + "ExportTable" + "\"");
    OutputXML = OutputXML.Replace("name=\"" + ResultDT.TableName + "\"", "name=\"" + "ExportTable" + "\"");
    System.IO.File.WriteAllText(fileName, OutputXML);
