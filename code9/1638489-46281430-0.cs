    Sub RemoveDuplicateTasks()
        
        Dim proj As Project
        Set proj = ActiveProject
    
        Application.Sort Key1:="Name", Ascending1:=True, Key2:="Resource Names", Ascending2:=True, Key3:="Unique ID", Ascending3:=True, Renumber:=False, Outline:=False
        Application.SelectAll
        Dim tsks As Tasks
        Set tsks = Application.ActiveSelection.Tasks
            
        Dim i As Integer
        Do While i < tsks.Count
            If tsks(i).Name = tsks(i + 1).Name And tsks(i).ResourceNames = tsks(i + 1).ResourceNames Then
                tsks(i + 1).Delete
            Else
                i = i + 1
            End If
        Loop
        
        Application.Sort Key1:="ID", Renumber:=False, Outline:=False
        Application.SelectBeginning
        
    End Sub
