    try
    { 
     foreach (DataGridViewRow row in dataGridView1.Rows) //looping through each records in datagridview
     { 
       //Update query
       strQuery = @"Update TableA Set ActiveInactive = @ActiveInactive --Boolean field
                    Where Id = @Id ";
       cmd = new SqlCommand(strQuery, // provide sql connection string here));
       cmd.Parameters.AddWithValue("@Id", row.Cells["SystemIdentifier"].Value); //reading Id of a particular record
       cmd.Parameters.AddWithValue("@ActiveInactive", SqlDbType.Bit).Value = (Convert.ToBoolean(row.Cells["ActiveInactive"].Value) ? 1 : 0);
       //reading Boolean field of a particular record
       cmd.ExecuteNonQuery();
     }
       MessageBox.Show("The records in the table has been updated.", "Information");
                       
    }
    catch (Exception err)
    {
        MessageBox.Show(err.Message.ToString(), "Error");
    }
