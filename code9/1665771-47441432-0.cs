       Public Function FillPDFFormSQL(pdfMasterPath As String, pdfFinalPath As String, SQL As String, Optional FlattenForm As Boolean = True, Optional PrintPDF As Boolean = False, Optional PrinterName As String = "", Optional AllowMissingFields As Boolean = False) As Boolean
        ' case matters SQL <-> PDF Form Field Names
        Dim pdfFormFields As AcroFields
        Dim pdfReader As PdfReader
        Dim pdfStamper As PdfStamper
        Dim s As String = ""
        Try
            If pdfFinalPath = "" Then pdfFinalPath = pdfMasterPath.Replace(".pdf", "_Out.pdf")
            Dim newFile As String = pdfFinalPath
            pdfReader = New PdfReader(pdfMasterPath)
            pdfStamper = New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create))
            pdfReader.Close()
            pdfFormFields = pdfStamper.AcroFields
            Dim dt As DataTable = Gen.GetDataTable(SQL)
            For i As Integer = 0 To dt.Columns.Count - 1
                s = dt.Columns(i).ColumnName
                If AllowMissingFields Then
                    If pdfFormFields.Fields.ContainsKey(s) Then
                        pdfFormFields.SetField(s, dt.Rows(0)(i).ToString.Trim)
                    Else
                        Debug.WriteLine($"Missing PDF Field: {s}")
                    End If
                Else
                    pdfFormFields.SetField(s, dt.Rows(0)(i).ToString.Trim)
                End If
            Next
            ' flatten the form to remove editing options
            ' set it to false to leave the form open for subsequent manual edits
            If My.Computer.Keyboard.CtrlKeyDown Then
                pdfStamper.FormFlattening = False
            Else
                pdfStamper.FormFlattening = FlattenForm
            End If
            pdfStamper.Close()
            If Not newFile.Contains("""") Then newFile = """" & newFile & """"
            If Not PrintPDF Then
                Process.Start(newFile)
            Else
                Dim sPDFProgramPath As String = INI.GetValue("OISForms", "PDFProgramPath", "C:\Program Files (x86)\Foxit Software\Foxit PhantomPDF\FoxitPhantomPDF.exe")
                If Not IO.File.Exists(sPDFProgramPath) Then MsgBox("PDF EXE not found:" & vbNewLine & sPDFProgramPath) : Exit Function
                If PrinterName.Length > 0 Then
                    Process.Start(sPDFProgramPath, "/t " & newFile & " " & PrinterName)
                Else
                    Process.Start(sPDFProgramPath, "/p " & newFile)
                End If
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            pdfStamper = Nothing
            pdfReader = Nothing
        End Try
    End Function
