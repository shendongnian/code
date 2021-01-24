    Sub add4000tasks()
    On Error Resume Next
    
    Dim myTask As task
    Dim myProject As Project
    resPool = Split("Allice,Bob,Claire,Dave", ",")
    
    For testRun = 0 To &HF '00001111
         
        testPreds = testRun And &H1 '00000001
        testOutlines = testRun And &H2 '00000010
        testDurations = testRun And &H4 '00000100
        testAssignments = testRun And &H8 '00001000
    
        If testPreds Then Debug.Print "Testing Predcessors"
        If testOutlines Then Debug.Print "Testing Outlines"
        If testDurations Then Debug.Print "Testing Durations"
        If testAssignments Then Debug.Print "Testing Resource Assignments"
        
        
        Application.Projects.Add
        Set myProject = ActiveProject
        Application.Calculation = pjManual
        
        starttime = Now
        
        Set myTask = myProject.Tasks.Add("Task 0")
        For a = 1 To 4000
            
            Set myTask = myProject.Tasks.Add("Task " & a)
            
            If testPreds Then
                myTask.Predecessors = Rnd * 10000000 Mod a + 1 'may fail if predecessor is also a parent
            End If
            
            If testOutlines Then
                If Rnd * 10000000 Mod 10 = 0 And myTask.OutlineLevel < 10 Then
                    myTask.OutlineIndent
                ElseIf Rnd * 10000000 Mod 10 = 1 And myTask.OutlineLevel > 1 Then
                    myTask.OutlineOutdent
                End If
            End If
            
            If testDurations Then
                myTask.Duration = Rnd * 10000000 Mod 50 & "d"
            End If
            
            If testAssignments Then
                myTask.ResourceNames = resPool(Rnd * 10000000 Mod UBound(resPool) + 1)
            End If
            
        
        Next
        
        Application.Calculation = pjAutomatic
        
        Debug.Print (Now - starttime) * 86400 & vbCrLf
        
        Application.FileCloseEx (pjDoNotSave)
        
    Next
    
