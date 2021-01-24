    Sub ShowSource()
            Dim ts As task = getSource()
    End Sub
    Private Async Function getSource() As Task
        Dim source As String = Await wb.GetBrowser().MainFrame.GetSourceAsync()
        Dim f As String = Application.StartupPath + "/currentSource.txt"
        Dim wr As StreamWriter = New StreamWriter(f, False, System.Text.Encoding.Default)
        wr.Write(source)
        wr.Close()
        System.Diagnostics.Process.Start(f)
    End Function
