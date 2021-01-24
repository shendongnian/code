    Imports Word = Microsoft.Office.Interop.Word
    
        Dim objWordApp As New Word.Application
        Dim objDoc As Word.Document
    	
        Private Sub Form1_Load(ByVal sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    	
            'Establish application path, replace appPath on deployment
            Dim appPath As String = Application.StartupPath()
    
            'Run application in foreground or background.  
            'If in background (false), be sure to add objDoc.close() and objWordApp.Quit()
            objWordApp.Visible = False
    		
            Dim objDoc As Word.Document = objWordApp.Documents.Open(appPath & "path.to.file", [ReadOnly]:=True)
    		
            objDoc = objWordApp.ActiveDocument
    		
            With objDoc
    		...Manipulate document...
    		End With
    		
            'clear objDoc object
            objDoc = Nothing
    
            'quit msWord
            lblStatus.Text = "Quitting MS Word"
            objWordApp.Quit()
    
            'clear objWord object
            objWordApp = Nothing
    
            'close com objects on parent system
            lblStatus.Text = "Releasing COM objects"
            If Not objDoc Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objDoc)
            End If
            If Not objWordApp Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objWordApp)
            End If
    
            'set filename
            lblStatus.Text = "Sending BLOB to DB"
            Dim filename As String = Path.GetFileName(saveString)
    
            'open a filestream
            Dim fs As FileStream = New FileStream(saveString, FileMode.Open, FileAccess.Read)
    
            'open a binary reader stream
            Dim br As BinaryReader = New BinaryReader(fs)
    
            'create array to store the BLOB
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
    
            'Write the BLOB to the DB and set box as unselected
            Dim cmdStoreBlob As SqlCommand = New SqlCommand("UPDATE TABLENAME SET
                COLUMN = @VAR, [SELECTED] = @VAR2 WHERE [SELECTED] = 'True'", connection)
            cmdStoreBlob.Parameters.Add("@VAR1", SqlDbType.VarBinary).Value = bytes
            cmdStoreBlob.Parameters.Add("@VAR2", SqlDbType.Bit).Value = 0
            cmdStoreBlob.ExecuteNonQuery()
    
            'close binary reader and file stream
            lblStatus.Text = "Cleaning Up"
            br.Close()
            fs.Close() 'close file stream
    
            'close SQL server connection
            connection.Close()
    
            'exit application
            Application.Exit()
        End Sub
    End Class
