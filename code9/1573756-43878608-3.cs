    private DataTable clipboardExcelToDataTable(bool blnFirstRowHasHeader = false)
    {
        string strTime = "S " + DateTime.Now.ToString("mm:ss:fff");
        var clipboard = Clipboard.GetDataObject();
        if (!clipboard.GetDataPresent("XML Spreadsheet")) return null;
    
        strTime += "\r\nRead " + DateTime.Now.ToString("mm:ss:fff");
        StreamReader streamReader = new StreamReader((MemoryStream)clipboard.GetData("XML Spreadsheet"));
        strTime += "\r\nFinish read " + DateTime.Now.ToString("mm:ss:fff");
        streamReader.BaseStream.SetLength(streamReader.BaseStream.Length - 1);
    
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(streamReader.ReadToEnd());
        strTime += "\r\nRead XML Document " + DateTime.Now.ToString("mm:ss:fff");
    
        XNamespace ssNs = "urn:schemas-microsoft-com:office:spreadsheet";
        DataTable dtData = new DataTable();
    
        var linqRows = xmlDocument.fwToXDocument().Descendants(ssNs + "Row").ToList<XElement>();
    
        for (int x = 0; x < linqRows.Max(a => a.Descendants(ssNs + "Cell").Count()); x++)
            dtData.Columns.Add("Column " + (x + 1).ToString());
    
        int intCol = 0;
    
        DataRow drCurrent;
    
        linqRows.ForEach(rowElement =>
            {
                intCol = 0;
                drCurrent = dtData.Rows.Add();
                rowElement.Descendants(ssNs + "Cell")
                    .ToList<XElement>()
                    .ForEach(cell => drCurrent[intCol++] = cell.Value);
            });
    
        if (blnFirstRowHasHeader)
        {
            int x = 0;
            foreach (DataColumn dcCurrent in dtData.Columns)
                dcCurrent.ColumnName = dtData.Rows[0][x++].ToString();
    
            dtData.Rows.RemoveAt(0);
        }
    
        strTime += "\r\nF " + DateTime.Now.ToString("mm:ss:fff");
    
        return dtData;
    }
