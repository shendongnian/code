    Sub TestRestrictDocument()
    
        If ActiveDocument.ProtectionType <> wdNoProtection Then
            ActiveDocument.Unprotect "000"
        End If
    
        ActiveDocument.Content.Editors.Add Word.WdEditorType.wdEditorEveryone
    
        Dim paragraph As paragraph
    
        For I = 1 To 5
        
            Set paragraph = ActiveDocument.Paragraphs(I)
        
            If I <> 4 Then
                paragraph.Range.Select
            
                Dim objEditor As Editor
            
                If Selection.Editors.Count > 0 Then
                    For X = 1 To Selection.Editors.Count
                        Selection.Editors(X).Delete
                    Next
                End If
            End If
    
        Next
    
        ActiveDocument.Protect Word.WdProtectionType.wdAllowOnlyReading, False, "000", False, True
    
    End Sub
