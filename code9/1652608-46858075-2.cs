    ''' <summary>
    ''' Converts a fixed width database to a .NET DataTable
    ''' </summary>
    ''' <param name="path">The location of the text file to convert</param>
    ''' <param name="headers">Indicates if the fixed width database contains a header row</param>
    ''' <returns>DataTable</returns>
    ''' <remarks>Only returns unique rows</remarks>
    Private Function ConvertToDataTable(ByVal path As String, ByVal headers As Boolean) As DataTable
        If Not IO.File.Exists(path) Then
            Throw New ArgumentException("The file does not exists.", "path")
        End If
    
        'Declare an object to return
        Dim dt As DataTable = Nothing
    
        'Create a connection object
        Dim con As OleDbConnection = Nothing
    
        'Database junk, always wrap in Try/Catch
        Try
            'Create a new instance the database connection
            con = New OleDbConnection($"Provider=Microsoft.Jet.OleDb.4.0;Data Source={IO.Path.GetDirectoryName(path)};Extended Properties=""Text;HDR={If(headers, "Yes", "No")};FMT=Fixed"";")
    
            'Create a new instance of a command object
            Using cmd As OleDbCommand = New OleDbCommand($"SELECT * FROM {path}", con)
                'Create a new instance of a dataadapter
                Using adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                    'Open the connection
                    con.Open()
    
                    'Create a new instance of a DataTable
                    dt = New DataTable
    
                    'Fill the data into the DataTable
                    adapter.Fill(dt)
    
                    'Close the connection
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine(ex.ToString())
        Finally
            'Check if the connection object was initialized
            If con IsNot Nothing Then
                If con.State = ConnectionState.Open Then
                    'Close the connection if it was left open(exception thrown)
                    con.Close()
                End If
    
                'Dispose of the connection object
                con.Dispose()
            End If
        End Try
    
        'Return the converted DataTable
        Return dt
    End Function
