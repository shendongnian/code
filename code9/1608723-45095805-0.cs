     Public Sub StratServices(ByVal servername As String)
            Try
                Dim service As ServiceController = New ServiceController(servername)
                If service.Status = ServiceControllerStatus.Stopped Then
                    service.Start()
                    service.Refresh()
                End If
            Catch ex As Exception
                MsgBox("You dont have Sql Srver in your Machine")
            End Try
        End Sub
    
    By use System.Serviceprocess
