    protected void generateProposal_Click(object sender, EventArgs e)
    {
        //the id of the prospect. Not clear from your question where this should come from
        int proposalID = 6;
    
        //sometimes a counter is just a counter
        int counter = 0;
    
        //clear old items from the dropdownlist
        DropDownList1.Items.Clear();
    
        //load the prospects from the database here and attach to dropdownlist
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand("prospect_select", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@id", SqlDbType.Int).Value = proposalID;
    
            try
            {
                //open the database connection
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
    
                //loop all rows and add them to the dropdownlist
                while (reader.Read())
                {
                    DropDownList1.Items.Insert(counter, new ListItem(reader["prospect_name"].ToString(), reader["prospect_version"].ToString(), true));
                    counter++;
                }
            }
            catch (Exception exception)
            {
                //handle the error if you want
            }
        }
    
        //call the javascript function to open the dialog box
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showPopup", "showPopup();", true);
    }
