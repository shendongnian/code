    SqlTransaction tr = null;
    try
    {
        string cmdText = @"insert into location(Storage, Shelf, columns, rows) 
                           values(@storage,@shelf,@columns,@rows);
                           select scope_identity()"; 
        using(SqlConnection sqlCon = new SqlConnection(.....))
        using(SqlCommand cmd = new SqlCommand(cmdText, sqlCon))
        {
             sqlCon.Open();
             using( tr = sqlCon.BeginTransaction())
             {
                 // Prepare all the parameters required by the command
                 cmd.Parameters.Add("@storage", SqlDbType.Int).Value = Convert.ToInt32(txtWarehouse.Text);
                 cmd.Parameters.Add("@shelf", SqlDbType.Int).Value = Convert.ToInt32(txtShelf.Text);
                 cmd.Parameters.Add("@columns", SqlDbType.Int).Value = Convert.ToInt32(txtColumn.Text );
                 cmd.Parameters.Add("@rows", SqlDbType.Int).Value = Convert.ToInt32(txtRow.Text);
                 // Execute the command and get back the result of SCOPE_IDENTITY
                 int newLocation = Convert.ToInt32(cmd.ExecuteScalar());
                 // Set the second command text
                 cmdText = @"insert into product(SKU, nimetus, minimum, maximum, quantity,location_ID,category_ID,OrderMail_ID) 
                             values (@sku, @nimetus,@min,@max,@qty,@locid,@catid,@ordid)";
                  // Build a new command with the second text
                  using(SqlCommand cmd1 = new SqlCommand(cmdText, sqlCon))
                  {
                      // Inform the new command we are inside a transaction
                      cmd1.Transaction = tr;
                  
                      // Add all the required parameters for the second command
                      cmd1.Parameters.Add("@sku", SqlDbType.NVarChar).Value = txtSku.Text;
                      cmd1.Parameters.Add("@nimetus",SqlDbType.NVarChar).Value = txtNimetus.Text;
                      cmd1.Parameters.Add("@locid", SqlDbType.Int).Value = newLocation;
                      .... and so on for the other parameters required
                      cmd1.ExecuteNonQuery();
                      // If we reach this point the everything is allright and
                      // we can commit the two inserts together
                      tr.Commit();
                 }
            }
        }
    }
    catch (Exception er)
    {
        // In case of exceptions do not insert anything...
        if(tr != null) 
           tr.Rollback();
        MessageBox.Show(er.Message);
    }
