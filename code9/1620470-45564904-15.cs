     Public Sub SaveViaTableValuedParameter()
     
      
     
       'Prepare the Table-valued Parameter'
     
      Dim objUniqueIntegerList As New DataTable
     
      Dim objColumn As DataColumn =
      objUniqueIntegerList.Columns.Add("TheInteger", _
     
      System.Type.GetType("System.Int32"))
     
       objColumn.Unique = True
     
      
     
       'Populate the Table-valued Parameter with the data to save'
     
       For Each Item As Product In Me.Values
     
         objUniqueIntegerList.Rows.Add(Item.ProductID)
     
       Next
     
      
     
       'Connect to the DB and save it.'
     
       Using objConn As New SqlConnection(DBConnectionString())
     
         objConn.Open()
     
         Using objCmd As New SqlCommand("dbo.DoTableValuedParameterInsert")
     
           objCmd.CommandType = CommandType.StoredProcedure
     
           objCmd.Connection = objConn
     
           objCmd.Parameters.Add("ProductIDs", SqlDbType.Structured)
     
      
     
           objCmd.Parameters(0).Value = objUniqueIntegerList
     
      
     
           objCmd.ExecuteNonQuery()
     
         End Using
     
         objConn.Close()
     
       End Using
     
     End Sub
