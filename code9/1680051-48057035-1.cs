    // Read XML
    InputXML = System.IO.File.ReadAllText(fileName);
    // now replace the Table Name
    InputXML = InputXML.Replace("<" + "ExportTable" + ">", "<" + ResultTable.TableName + ">");
    InputXML = InputXML.Replace("</" + "ExportTable" + ">", "</" + ResultTable.TableName + ">");
    InputXML = InputXML.Replace("MainDataTable=\"" + "ExportTable" + "\"", "MainDataTable=\"" + ResultTable.TableName + "\"");
    InputXML = InputXML.Replace("name=\"" + "ExportTable" + "\"", "name=\"" + ResultTable.TableName + "\"");
    string TempFileName = "TempDumpFile.idt";
    System.IO.File.WriteAllText(TempFileName, InputXML);
    ResultTable.ReadXmlSchema(TempFileName);
    ResultTable.ReadXml(TempFileName);
    System.IO.File.Delete(TempFileName);
