      Dim instance As ConflictResolutionMode =  ConflictResolutionMode.AlwaysOverwrite
             
             
                Dim tasksFolder As Folder = Folder.Bind(clientTZService, New FolderId(WellKnownFolderName.Tasks, useremail))
                
                tasksFolder.Load()
                For Each task1 As Task In tasksFolder.FindItems(New ItemView(100))
                    task1.Load()
                    If task1.ConversationId = taskrow("OutlookTaskID") Then
                        task1.PercentComplete = 100
                        task1.Update(instance)
                        Exit For
                    End If
                Next
