    // Checking to see if the sBillItemBartxt.Text is not empty.
    if (!string.IsNullOrWhiteSpace(sBillItemBartxt.Text))
    {
        try
        {
            // the using statement ensures that Dispose is called even if an exception occurs while you are calling methods on the object.
            using (cn)
            {
                // Checking to see if the connection to the Database is all ready open.
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                // Building the SQL Query.
                SqlCommand cmd = new SqlCommand("SELECT itmName, itmBar from item where itmBar = @itemBarcode", cn);
                cmd.Parameters.Add(new SqlParameter("@itemBarcode", sBillItemBartxt.Text.Trim()));
                cmd.CommandType = CommandType.Text;
                // Executing the Query on the Database.
                SqlDataReader resultsReader = cmd.ExecuteReader();
                // Checking to see if the query has results
                if (resultsReader.HasRows)
                {
                    Dictionary<string, string> results = new Dictionary<string, string>();
                    // Results found looping through each result
                    while (resultsReader.Read())
                    {
                        results.Add(resultsReader["itmBar"].ToString(), resultsReader["itmName"].ToString());
                    }
                    // Checking to see if only one record was returned.
                    if (results.Count == 1)
                    {
                        // One item found displaying item name.
                        sBillItemNametxt.Text = results[sBillItemBartxt.Text.Trim()];
                        sBillItemNametxt.ReadOnly = true;
                        
                        // not sure what this function call is doing
                        bindExDateGrid();
                    }
                    else
                    {
                        // Multiple records were found not sure if you need this.
                        MessageBox.Show("Multiple barcodes was found please try again");
                    }
                }
                else
                {
                    // No Records was found in the database.
                    MessageBox.Show("No product found please try again");
                }
            }
        }
        catch (SqlException ex)
        {
            // There was an SQL error.
            MessageBox.Show("An error occurred while Querying the database:" + Environment.NewLine + ex.Message);
        }
        catch (Exception ex)
        {
            // Final catch
            MessageBox.Show("Unknown Error:" + Environment.NewLine + ex.Message);
        }
    }
    // Resetting form elements.
    sBillItemBartxt.Text = "";
    sBillItemBartxt.Focus();
