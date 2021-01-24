    Sub TestMacro()
    
    ' Create a connection object.
    Dim cnPubs As ADODB.Connection
    Set cnPubs = New ADODB.Connection
    
    ' Provide the connection string.
    Dim strConn As String
    
    'Use the SQL Server OLE DB Provider.
    strConn = "PROVIDER=SQLOLEDB;"
    
    'Connect to the Pubs database on the local server.
    strConn = strConn & "DATA SOURCE=(local);INITIAL CATALOG=NORTHWIND.MDF;"
    
    'Use an integrated login.
    strConn = strConn & " INTEGRATED SECURITY=sspi;"
    
    'Now open the connection.
    cnPubs.Open strConn
    
    ' Create a recordset object.
    Dim rsPubs As ADODB.Recordset
    Set rsPubs = New ADODB.Recordset
    
    With rsPubs
        ' Assign the Connection object.
        .ActiveConnection = cnPubs
        ' Extract the required records.
        .Open "SELECT * FROM Categories"
        ' Copy the records into cell A1 on Sheet1.
        Sheet1.Range("A1").CopyFromRecordset rsPubs
        
        ' Tidy up
        .Close
    End With
    
    cnPubs.Close
    Set rsPubs = Nothing
    Set cnPubs = Nothing
    
    End Sub
