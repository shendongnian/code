    [Microsoft.SqlServer.Server.SqlProcedure]
    
    public static void SaveXMLOutput(SqlXml XmlData, SqlString Filename)
    
    {
    
                 //Save the XML data being passed to the SP to a file location
    
          //specify the name of the file suppiled to the SP
    
          XmlDocument xmlDoc = new XmlDocument();
    
          SqlPipe output = SqlContext.Pipe;
    
          xmlDoc.LoadXml(XmlData.Value);
    
          xmlDoc.Save(Filename.Value);
    
    }
