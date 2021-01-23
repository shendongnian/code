      <TestMethod()> Public Sub getDocText()
      Dim filepath As String = "C:\Test Table.docx"
      If File.Exists(filepath) AndAlso (Path.GetExtension(filepath).ToUpper.Equals(".DOCX") Or Path.GetExtension(filepath).ToUpper.Equals(".DOC")) Then
         Dim app As Word.Application = New Word.Application
         Dim doc As Word.Document = app.Documents.Open(filepath)
         Dim topic1Range As Word.Range = doc.Content
         Dim topic2Range As Word.Range = doc.Content
         Dim Find As Word.Find = topic1Range.Find()
         Find.Execute("1.2 The headline of paragraph3")
         Dim Find2 As Word.Find = topic2Range.Find()
         Find2.Execute("1.3 The headline of paragraph3")
         Dim contentRange As Word.Range = doc.Range(topic1Range.End, topic2Range.Start)
         MsgBox(contentRange.Tables.Count)
         app.Quit()
      End If
    End Sub
