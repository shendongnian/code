    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        //get the current datagrid item from the sender
        GridViewRow row = (GridViewRow)(((Control)sender).NamingContainer);
        //get the correct programid from the datakeys
        int programid = Convert.ToInt32(GridView1.DataKeys[row.DataItemIndex].Values[0]);
        //cast the sender back to a checkbox
        CheckBox cb = sender as CheckBox;
        //create the sql string
        string sqlString = "UPDATE programs SET ActivatedBy = @ActivatedBy WHERE (programid = @programid)";
        //create a connection to the db and a command
        using (SqlConnection connection = new SqlConnection(myConnectionString))
        using (SqlCommand command = new SqlCommand(sqlString, connection))
        {
            //set the proper command type
            command.CommandType = CommandType.Text;
            //replace the parameters
            command.Parameters.Add("@ActivatedBy", SqlDbType.Bit).Value = cb.Checked;
            command.Parameters.Add("@programid", SqlDbType.Int).Value = programid;
            try
            {
                //open the db and execute the sql string
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //catch any errors like unable to open db or errors in command. view with ex.Message
                Response.Write(ex.Message);
            }
        }
    }
