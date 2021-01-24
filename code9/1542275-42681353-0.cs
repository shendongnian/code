        Private strFolderPath As String = String.Empty
        Public Overrides Sub PreExecute()
            MyBase.PreExecute()
            strFolderPath = Variables.RowCount
        End Sub
        Public Overrides Sub CreateNewOutputRows()
            Dim strFiles() As String = IO.Directory.GetFiles(strFolderPath, "*.csv", IO.SearchOption.AllDirectories)
            For Each strFiles As String In strFiles
                With Output0Buffer
                    .AddRow()
                    .OutFilename = strFiles
                End With
            Next
        End Sub
