    For Each row As GridViewRow In GridView //Loop through all the rows in the GridView
        Dim cbProd As CheckBox = row.Cells(0).FindControl("chkRow") //Finds the checkbox in the first column
        Dim hfProd As HiddenField = row.Cells(0).FindControl("hfProdID") //Finds the HiddenField in the first column where ProductID is stored
        If cbProd.Checked = True Then //Checks if the current checkbox is selected, if yes, execute the Store Procedure by passing the Product ID as the parameter.
            Dim sqlConnStr As String = (put actual connection string here)
            Dim sqlCmdStr As String = (put the name of your Stored Procedure here)
            Using sqlConn As New SqlConnection(sqlConnStr)
                Using sqlCmd As New SqlCommand(sqlCmdStr, sqlConn) With { .CommandType = StoredProcedure}
                    sqlCmd.Parameters.Clear
                    sqlCmd.Parameters.AddWithValue("ProductID", hfProd.Value) //Product ID saved in HiddenField
                    sqlCmd.ExecuteNonQuery()
                End Using
            End Using
        End If
    Next row
