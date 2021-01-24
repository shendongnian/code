    Dim result As HttpResponseMessage = New HttpResponseMessage(HttpStatusCode.OK) With {
        .Content = New PushStreamContent(Async Function(outStream, httpContent, context)
            Dim writer As StreamWriter = New StreamWriter(outStream)
            Await writer.WriteLineAsync("""Header 1"",""Header 2"",""Header 3""")
            For Each item In returnItems
                Await writer.WriteLineAsync("""" & item.Col1.ToString & """,=""" & item.Col2.ToString & """,=""" & item.Col3.ToString & """")
                Await writer.FlushAsync()
            Next
            outputStream.Close()
        End Function)}
    result.Content.Headers.ContentType = New Headers.MediaTypeHeaderValue("text/csv")
    result.Content.Headers.ContentDisposition = New _
      Headers.ContentDispositionHeaderValue("attachment") With {.FileName = "MyCSV.csv"}
    Return result
