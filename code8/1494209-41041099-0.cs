        Public Sub Start_DB_Connection(servername As String,user As String,password As String,dbname As String)
            Try
                db_con As New SqlConnection
                If Not db_con Is Nothing Then db_con.Close()
                db_con.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; connection timeout=1;", servername, user, password, dbname)
            
                If clsCheckConnection.IsSQLServerOnline(db_con.DataSource) = True Then
                    db_con.Open()
                Else
                    // show error
                End If
            Catch ex As Exception
                // show error
            End Try
        End Sub
