    Dim rgx As New Regex("^[0-9]{16}$")
    Dim docs As List(Of PdfDocument) = New List(Of PdfDocument)
    Dim i As Integer = 0
    Dim p As String = Application.UserAppDataPath + "\part{0}.pdf"
    ' Root Level Bookmarks
    For Each rootb In document.Outlines
        ' Ensure Account Number Type
        If rgx.IsMatch(rootb.Title) Then
            Dim newdoc As PdfSharp.Pdf.PdfDocument = New PdfDocument
            Dim rp As PdfPage = newdoc.AddPage(rootb.DestinationPage)
            Dim outline As PdfOutline = newdoc.Outlines.Add(rootb.Elements.GetString("/Title"), rp, True, PdfOutlineStyle.Bold, XColors.Red)
            Dim child As PdfDictionary = rootb.Elements.GetDictionary("/First")
            While child IsNot Nothing
                Dim item As PdfOutline = child
                Dim cp As PdfPage = newdoc.AddPage(item.DestinationPage)
                outline.Outlines.Add(item.Elements.GetString("/Title"), cp, True)
                child = child.Elements.GetDictionary("/Next")
            End While
    
            newdoc.Save(String.Format(p, i))
            i += 1
    Next
