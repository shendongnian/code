    Protected Sub Page_PreRender(sender As Object, e As System.EventArgs) Handles Me.PreRender
        Dim excelStream As MemoryStream
        Dim excelFilename As String
        excelStream = CType(Cache("ExcelViewerContent"), MemoryStream)
        excelFilename = CType(Cache("ExcelViewerFilename"), String)
        Response.ClearContent()
        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache)
        Response.AddHeader("content-disposition", Convert.ToString("attachment; filename=") & excelFilename)
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        Response.BinaryWrite(excelStream.ToArray())
        Response.Flush()
        HttpContext.Current.ApplicationInstance.CompleteRequest()
    End Sub
