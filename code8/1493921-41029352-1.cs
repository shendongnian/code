    If DataTableofFiles IsNot Nothing AndAlso DataTableofFiles.Rows.Count > 0 Then 
      List<string> allAFileNames = new List<string>();
      List<string> allBFileNames = new List<string>();
      List<string> allCFileNames = new List<string>();
      For Each row as DataRow In DataTableofFiles.Rows
        If row("FILENAME").ToString.StartsWith("a") Then
          Dim a_WriteResultstoA as String = "a.csv"
          allAFileNames.Add(row("FILENAME"));
        ElseIf row("FILENAME").ToString.StartsWith("b") Then
          Dim b_WriteResultstoB as String = "b.csv"
          allBFileNames.Add(row("FILENAME"));
        ElseIf row("FILENAME").ToString.StartsWith("C") Then
          Dim c_WriteResultstoC as String = "c.csv"
          allCFileNames.Add(row("FILENAME"));
        End If
      Next
      if (allAFileNames.Count > 0)
      {
            functionfindfiles(A_folder, allAFileNames, a_WriteResultstoA);
      }
      if (allBFileNames.Count > 0)
      {
            functionfindfiles(B_folder, allBFileNames, b_WriteResultstoB)
      }
      if (allAFileNames.Count > 0)
      {
            functionfindfiles(C_folder, allCFileNames, c_WriteResultstoC)
      }
    End If
    
    Private Sub functionfindfiles(sourcefolder As String, List<string> listOfFileNames, writetofile As String)
            Try
                For Each f As String In Directory.EnumerateFiles(sourcefolder, "*.*", SearchOption.AllDirectories)  '<-- file enumeration
                        foreach (var filename in listOfFileNames)
                        {
                        If Path.GetFileName(f).Equals(filename, StringComparison.OrdinalIgnoreCase) Then
                            Using fs As New FileStream(writetofile, FileMode.Append, FileAccess.Write, FileShare.Write)
                                Using sw As StreamWriter = New StreamWriter(fs)
                                    If Not New FileInfo(writetofile).Length > 0 Then
                                        For i As Integer = 0 To DataTableofFiles.Columns.Count - 1 Step 1
                                            sw.Write(DataTableofFiles.Columns(i).ToString)
    
                                            If i < DataTableofFiles.Columns.Count - 1 Then
                                                sw.Write(",")
                                            End If
                                        Next
    
                                        sw.WriteLine()
                                    End If
    
                                    For Each row As DataRow In DataTableofFiles.Rows
                                        If row("FILENAME").ToString = filename Then
                                            For i As Integer = 0 To DataTableofFiles.Columns.Count - 1 Step 1
                                                If Not Convert.IsDBNull(row(i)) Then
                                                    sw.Write(row(i).ToString.Replace(vbLf, "").Replace(",", ";"))
                                                End If
    
                                                If i < DataTableofFiles.Columns.Count - 1 Then
                                                    sw.Write(",")
                                                End If
                                            Next
    
                                            sw.WriteLine()
                                        End If
                                    Next
                                End Using
                            End Using
                        Else
                            'write results that are not found here to a file
                        End If
                        }
                Next
            Catch ex As Exception
        MessageBox.Show(ex.Message)
            End Try
    End Sub
