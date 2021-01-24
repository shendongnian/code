    Public Shared Sub ReplaceBookmarkText(ByVal doc As Microsoft.Office.Interop.Word.Document, ByVal bookmarkName As String, ByVal text As String)
        If (doc.Bookmarks.Exists(bookmarkName)) Then
            Dim range As Microsoft.Office.Interop.Word.Range = doc.Bookmarks(bookmarkName).Range
            range.Text = text
            doc.Bookmarks.Add(bookmarkName, range)
        End If
    End Sub
