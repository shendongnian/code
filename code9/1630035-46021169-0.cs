    Private Sub btnExtractMerge_Click(sender As Object, e As EventArgs) Handles btnExtractMerge.Click
            txtCurSetupMessages.Text = ""
            ShowMessage(txtCurSetupMessages, "Extract & Merge Process Started")
    
            'get and check the paths / files from the form 
            Dim baseDir As String = txtCurSetupBaseDataFolder.Text
            Dim baseInvDir As String = txtCurSetupInvoicesFolder.Text
            Dim baseFileName As String = txtEMBaseFile.Text
            Dim targetFileName As String = txtEMTargetFile.Text
    
            If String.IsNullOrWhiteSpace(baseDir) Then
                ShowMessage(txtCurSetupMessages, "Base folder empty!")
                Exit Sub
            End If
            If String.IsNullOrWhiteSpace(baseInvDir) Then
                ShowMessage(txtCurSetupMessages, "Base invoice folder name empty!")
                Exit Sub
            End If
            If String.IsNullOrWhiteSpace(baseFileName) Then
                ShowMessage(txtCurSetupMessages, "Base file name empty!")
                Exit Sub
            End If
            If String.IsNullOrWhiteSpace(targetFileName) Then
                ShowMessage(txtCurSetupMessages, "Target file name empty!")
                Exit Sub
            End If
            If Not Directory.Exists(baseDir) Then
                ShowMessage(txtCurSetupMessages, "Base folder does not exist!")
                Exit Sub
            End If
            baseInvDir = System.IO.Path.Combine(baseDir, baseInvDir)
            If Not Directory.Exists(baseInvDir) Then
                ShowMessage(txtCurSetupMessages, "Base invoice folder does not exist!")
                Exit Sub
            End If
    
            'get the invoice files
            Dim dirInfo As DirectoryInfo = New DirectoryInfo(baseInvDir)
            Dim files As FileInfo() = dirInfo.GetFiles("*.pdf")
            If files.Length <= 0 Then
                ShowMessage(txtCurSetupMessages, "Invoices missing!")
                Exit Sub
            End If
    
            baseFileName = System.IO.Path.Combine(baseDir, baseFileName)
            If Not File.Exists(baseFileName) Then
                ShowMessage(txtCurSetupMessages, "Base file missing!")
                Exit Sub
            End If
    
            targetFileName = System.IO.Path.Combine(baseDir, targetFileName)
            If File.Exists(targetFileName) Then
                File.Delete(targetFileName)
            End If
    
            Dim tempSource As String = System.IO.Path.Combine(baseDir, "tempSource.pdf")
            If File.Exists(tempSource) Then
                File.Delete(tempSource)
            End If
    
            'copy the base file as temp file
            File.Copy(baseFileName, tempSource, True)
    
            'do action 
            Dim iteration As Integer = 1
            Dim totalPages As Integer = 0
            Dim page As Integer = 0
    
            Dim temp As String = System.IO.Path.Combine(baseDir, "temp.pdf")
            Dim tempBefore As String = System.IO.Path.Combine(baseDir, "tempBefore.pdf")
            Dim tempAfter As String = System.IO.Path.Combine(baseDir, "tempAfter.pdf")
            Dim reader As PdfReader = Nothing
    
            For Each myFile As FileInfo In files
    
                If File.Exists(temp) Then File.Delete(temp)
                If File.Exists(tempBefore) Then File.Delete(tempBefore)
                If File.Exists(tempAfter) Then File.Delete(tempAfter)
    
                'get total pages in the pdf
                reader = New PdfReader(tempSource)
                totalPages = reader.NumberOfPages
                reader.Close()
                If totalPages = 0 Then
                    ShowMessage(txtCurSetupMessages, String.Format("0 pages found in the source file"))
                    Exit For
                End If
    
                'find page number, this is the page after which we'll place the invoice pdf 
                page = FindPageNo(tempSource, 1, myFile.Name.ToUpper.Replace(".PDF", ""))
                If page <= 0 Then Continue For
    
                ShowMessage(txtCurSetupMessages, String.Format("Processing Invoice:{0} Page:{1} InvoiceFile:{2}", Format(iteration, "000"), Format(page + 1, "000"), myFile.Name))
    
                If page = totalPages Then
                    'append the invoice file to the end 
                    AddDocuments(temp, tempSource, myFile.FullName, "")
                Else
                    'divide the pages into temp before and temp after then put together
                    BuildTempBeforeAndAfter(tempSource, tempBefore, tempAfter, page, totalPages)
                    'now put together
                    AddDocuments(temp, tempBefore, myFile.FullName, tempAfter)
                End If
    
                'move the temp into temp source
                If File.Exists(temp) Then
                    File.Copy(temp, tempSource, True)
                End If
    
                iteration += 1
            Next
    
            'clean reader, used for temp number of pages 
            If Not reader Is Nothing Then reader.Close()
    
            'clean the temp files used by the loop 
            If File.Exists(temp) Then File.Delete(temp)
            If File.Exists(tempBefore) Then File.Delete(tempBefore)
            If File.Exists(tempAfter) Then File.Delete(tempAfter)
    
            'move temp source to target file and delete 
            If File.Exists(tempSource) Then
                File.Copy(tempSource, targetFileName, True)
                File.Delete(tempSource)
            End If
    
            ShowMessage(txtCurSetupMessages, "Process Completed")
        End Sub
    
    Private Function FindPageNo(ByVal sourceFiles As String, ByVal startpage As Integer, ByVal invno As String) As Integer
            Dim i As Integer
            Dim str1 As String
            Dim pos1 As Integer, pos2 As Integer
            Dim bgReader As PdfReader
            Dim pagen As Integer
            If File.Exists(sourceFiles) Then
                bgReader = New PdfReader(sourceFiles)
    
                If startpage > bgReader.NumberOfPages Then
                    FindPageNo = -1  'error. invalid
                    bgReader.Close()
                End If
    
                pagen = 0
                For i = startpage To bgReader.NumberOfPages
                    str1 = pdftextextractor.GetTextFromPage(bgReader, i)
                    pos1 = str1.IndexOf("Invoice No:")
                    pos2 = str1.IndexOf("Phone:")
                    If pos2 > pos1 Then
                        If str1.Substring(pos1 + 11, pos2 - pos1 - 11).Trim.Equals(invno) = True Then
                            pagen = i  'found the page
                            'bgReader.Close()
                            'Exit Function
                        Else
                            If pagen <> 0 Then
                                'we found the page no. so no need to go further.
                                'exit now
                                FindPageNo = pagen  'last page found
                                bgReader.Close()
                                Exit Function
                            End If
                        End If
                    End If
                Next i
                bgReader.Close()
            End If
            If pagen <> 0 Then
                FindPageNo = pagen  'last page found
            Else
                FindPageNo = 0  'not found
            End If
    
        End Function
    
        Private Function BuildTempBeforeAndAfter(ByVal tempSource As String, ByVal tempBefore As String, ByVal tempAfter As String, ByVal endPage As Integer, ByVal totalPages As Integer) As Boolean
            Dim reader As PdfReader = Nothing
            Dim copy As PdfCopy = Nothing
            Dim doc As Document = Nothing
            Dim impPage As PdfImportedPage = Nothing
            Dim isBuild As Boolean = True
            Try
                reader = New PdfReader(tempSource)
                doc = New Document(reader.GetPageSizeWithRotation(1))
                'before file
                copy = New PdfCopy(doc, New FileStream(tempBefore, FileMode.Create))
                doc.Open()
                For index = 1 To endPage
                    impPage = copy.GetImportedPage(reader, index)
                    copy.AddPage(impPage)
                Next
                copy.Close()
                doc.Close()
                'after file 
                doc = New Document(reader.GetPageSizeWithRotation(1))
                copy = New PdfCopy(doc, New FileStream(tempAfter, FileMode.Create))
                doc.Open()
                For index = endPage + 1 To totalPages
                    impPage = copy.GetImportedPage(reader, index)
                    copy.AddPage(impPage)
                Next
                reader.Close()
                copy.Close()
                doc.Close()
            Catch ex As Exception
                isBuild = False
            Finally
                'clean the objects 
                If Not reader Is Nothing Then reader.Close()
                If Not doc Is Nothing Then doc.Close()
                If Not reader Is Nothing Then reader.Close()
            End Try
            Return isBuild
        End Function
    
        Private Function AddDocuments(ByVal targetFile As String, ByVal addFile1 As String, ByVal addFile2 As String, ByVal addFile3 As String) As Boolean
            Dim reader As PdfReader = Nothing
            Dim copy As PdfCopy = Nothing
            Dim doc As Document = Nothing
            Dim isAdded As Boolean = True
            Try
                doc = New Document
                copy = New PdfSmartCopy(doc, New FileStream(targetFile, FileMode.Create))
                doc.Open()
                'add file 1
                If Not String.IsNullOrWhiteSpace(addFile1) Then
                    reader = New PdfReader(addFile1)
                    copy.AddDocument(reader)
                    reader.Close()
                End If
                'add file 2 
                If Not String.IsNullOrWhiteSpace(addFile2) Then
                    reader = New PdfReader(addFile2)
                    copy.AddDocument(reader)
                    reader.Close()
                End If
                'add file 3 
                If Not String.IsNullOrWhiteSpace(addFile3) Then
                    reader = New PdfReader(addFile3)
                    copy.AddDocument(reader)
                    reader.Close()
                End If
                copy.Close()
                doc.Close()
            Catch ex As Exception
                isAdded = False
            Finally
                'clean the objects 
                If Not reader Is Nothing Then reader.Close()
                If Not doc Is Nothing Then doc.Close()
                If Not reader Is Nothing Then reader.Close()
            End Try
            Return isAdded
        End Function
