    Dim stream As New System.IO.MemoryStream()
    Using document As SpreadsheetDocument = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook, True)
        WriteExcelFile(ds, document)
    End Using
    stream.Flush()
    stream.Position = 0
        
    If (stream.Length > 0) Then
        HttpRuntime.Cache.Remove("ExcelViewerFilename")
        HttpRuntime.Cache.Add("ExcelViewerFilename", filename, Nothing, DateTime.Now.AddHours(1), Nothing, CacheItemPriority.Normal, Nothing)
        HttpRuntime.Cache.Remove("ExcelViewerContent")
        HttpRuntime.Cache.Add("ExcelViewerContent", stream, Nothing, DateTime.Now.AddHours(1), Nothing, CacheItemPriority.Normal, Nothing)                    
        Dim url As String = "/quotes/ExcelViewer.aspx"
        Response.Redirect(url, False)
        HttpContext.Current.ApplicationInstance.CompleteRequest()    
    Else
        Throw New HttpException("Error Creating File")
    End If
