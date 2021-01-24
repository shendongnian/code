       Sub ExportGridViewToPDF(Response As HttpResponse, ReportTitle As String, SubTitle As String)
        Response.ClearContent()
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "attachment;filename=test.pdf")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Dim pdfDoc As New Document(PageSize.LETTER, 10.0F, 10.0F, 10.0F, 0.0F)
        Dim htmlparser As New HTMLWorker(pdfDoc)
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
        pdfDoc.Open()
        Dim c As New Chunk(ReportTitle & vbLf, FontFactory.GetFont("Segoe UI", 14))
        Dim p As New Paragraph()
        p.Alignment = Element.ALIGN_CENTER
        p.Add(c)
        Dim chunk1 As New Chunk(SubTitle & vbLf, FontFactory.GetFont("Segoe UI", 8))
        Dim empty As New Chunk(" ")
        Dim p1 As New Paragraph()
        p1.Alignment = Element.ALIGN_LEFT
        p1.Font.SetStyle("underline")
        p1.Add(chunk1)
        pdfDoc.Add(p)
        pdfDoc.Add(p1)
        pdfDoc.Add(empty)
        Dim sb As New StringBuilder()
        sb.Append(" <table>")
        sb.Append("<tr>")
        sb.Append("<th>test</th>")
        sb.Append("</tr>")
        For i As Integer = 0 To 500000
            sb.Append("<tr><td>" & i & "</td></tr>")
        Next
        sb.Append("</table>")
        For i As Integer = 0 To 1000
            Threading.Thread.Sleep(1)
        Next
        Dim sr As New StringReader(sb.ToString())
        htmlparser.Parse(sr)
        pdfDoc.Close()
        Response.Write(pdfDoc)
        Response.End()
    End Sub
    Private Sub test_Click(sender As Object, e As EventArgs) Handles test.Click
        ExportGridViewToPDF(Response, "test", "sub title")
    End Sub
