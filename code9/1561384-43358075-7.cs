        foreach (GridViewRow rw in GridView.Rows) //Loop through all the rows in the GridView
        {
            if(rw.RowType == DataControlRowType.DataRow) //Checks if current row in the loop is a valid DataRow, not a Header or Footer row (which doesn't include the CheckBox and the data)
            {
                CheckBox cbProd = (CheckBox)rw.Cells[0].FindControl("chkRow"); //Finds the checkbox in the first column
                HiddenField hfProd = (HiddenField)rw.Cells[0].FindControl("hfProdID"); //Finds the HiddenField in the first column where ProductID is stored
                if(cbProd.Checked == true)  //Checks if the current checkbox is selected, if yes, execute the UPDATE query by passing the Product ID as the parameter.
                {
                    string sqlConnStr = ("put actual connection string here");
                    string sqlCmdStr = ("UPDATE Products SET Active = 0 WHERE ProductID = @ProductID"); //UPDATE query
                    using(SqlConnection sqlConn = new SqlConnection(sqlConnStr))
                    {
                        using(SqlCommand sqlCmd = new SqlCommand(sqlCmdStr, sqlConn))
                        {
                            sqlConn.Open();
                            sqlCmd.Parameters.Clear();
                            sqlCmd.Parameters.AddWithValue("ProductID", hfProd.Value); //Product ID saved in HiddenField
                            sqlCmd.ExecuteNonQuery();
                            sqlConn.Close();
                        }
                    }
                }
            }
        }
