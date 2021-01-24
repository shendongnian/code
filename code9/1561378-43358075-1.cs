        foreach (GridViewRow rw in GridView.Rows) //Loop through all the rows in the GridView
        {
            CheckBox cbProd = (CheckBox)rw.Cells[0].FindControl("chkRow"); //Finds the checkbox in the first column
            HiddenField hfProd = (HiddenField)rw.Cells[0].FindControl("hfProdID"); //Finds the HiddenField in the first column where ProductID is stored
            if(cbProd.Checked == true)  //Checks if the current checkbox is selected, if yes, execute the Store Procedure by passing the Product ID as the parameter.
            {
                string sqlConnStr = ("put actual connection string here");
                string sqlCmdStr = ("put the name of your Stored Procedure here");
                using(SqlConnection sqlConn = new SqlConnection(sqlConnStr))
                {
                    using(SqlCommand sqlCmd = new SqlCommand(sqlCmdStr, sqlConn))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.Clear();
                        sqlCmd.Parameters.AddWithValue("ProductID", hfProd.Value); //Product ID saved in HiddenField
                        sqlCmd.ExecuteNonQuery();
                    }
                }
            }
        }
