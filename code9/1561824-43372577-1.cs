    private void btnAdd_Click(object sender, EventArgs e)
    {
    	//find all checkbox controls in group,  get selected one  and get its text. 
    	string name = groupBox1.Controls.OfType<CheckBox>().FirstOrDefault(cb => cb.Checked).Text;
    	string model = groupBox2.Controls.OfType<CheckBox>().FirstOrDefault(cb => cb.Checked).Text;
    	string color = groupBox3.Controls.OfType<CheckBox>().FirstOrDefault(cb => cb.Checked).Text;
    
    	//connection
    	SqlConnection con = new SqlConnection(conString);
    	//command text (WITH PARAMETERS!)
    	string cmdText =
    		@"
    			INSERT INTO Demo_Table 
    				(ID,Customer_Name,Item_Name, item_model, item_color) 
    			VALUES 
    				(@id, @customer_name, @item_name, @item_model, @item_color)
    		";
    	SqlCommand cmd = new SqlCommand(cmdText, con);
    	//add params
    	cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = txtBoxID.Text;
    	cmd.Parameters.Add("@customer_name", SqlDbType.VarChar).Value = txtBoxName.Text;
    	cmd.Parameters.Add("@item_name", SqlDbType.VarChar).Value = name;
    	cmd.Parameters.Add("@item_model", SqlDbType.VarChar).Value = model;
    	cmd.Parameters.Add("@item_color", SqlDbType.VarChar).Value = color;
    	//execute query
    	sqlcmd.ExecuteNonQuery();
    	con.Close();
    	MessageBox.Show("Data added to table");
    }
