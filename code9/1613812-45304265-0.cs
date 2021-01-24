    Private Sub ReplaceWorkDocText()
        Dim objApplication As Microsoft.Office.Interop.Word.ApplicationClass = Nothing
        Dim range As Microsoft.Office.Interop.Word.Range 
        Dim objDocument As Microsoft.Office.Interop.Word.Document = Nothing
        Dim findText As String = "Address"
        Dim replaceText As String = "Park Royal House No: 3301 Wing - D" + _
                                    vbCrLf + "City: xxxx" + _
                                    vbCrLf + "State: YY" + _
                                    vbCrLf + "Zip: 100215"
    
        objApplication = New Microsoft.Office.Interop.Word.ApplicationClass()
        objDocument = objApplication.Documents.Open("C:\TEST\FORM0001.docx")
        
        range= objDocument.Range
        With range.Find
            .Text = findText
            .Forward = True
        End With
        While range.Find.Execute(findText, MatchWholeWord:=True)
            range.Text = replaceText
            Exit While
        End While
    End Sub
