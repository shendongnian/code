    protected void btn_Submit_Click(object sender, EventArgs e)
    {
    	List<string> selectedCheckboxes = new List<string>()
    	foreach (GridViewRow row in gvImage.Rows)
    	{
    		if (row.RowType == DataControlRowType.DataRow)
    		{	
    			bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
    			if (isChecked)
    			{
    				selectedCheckboxes.Add(row.Cells[1].Controls.OfType<TextBox>().FirstOrDefault().Text);
    			}
    		}
    	}
    	
    	String strConnString = ConfigurationManager.ConnectionStrings["CONNECTION1"].ConnectionString;
    	SqlConnection con = new SqlConnection(strConnString);
    	string str = "SELECT  * FROM AllProduct WHERE PId in ";
    	SqlCommand cmd = new SqlCommand();
    	cmd.Connection = con;
    	for (int i = 0; i < selectedCheckboxes.Count; i++)
    		cmd.Parameters.AddWithValue("@PId" + i.ToString(), selectedCheckboxes[i]);
    	str += "(" + String.Join(",", cmd.Parameters.Select(x => x.Name)) + ")";
    	cmd.CommandText = str;
    	DataSet objDs = new DataSet();
    	SqlDataAdapter dAdapter = new SqlDataAdapter();
    	dAdapter.SelectCommand = cmd;
    	con.Open();
    	dAdapter.Fill(objDs);
    	con.Close();
    	if (objDs.Tables[0].Rows.Count > 0)
    	{
    		cmd.CommandType = CommandType.Text;
    		using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
    		{
    			using (DataTable dt = new DataTable())
    			{
    				sda.Fill(dt);
    				GridView1.DataSource = dt;
    		GridView1.DataBind();
    		GridView1.Visible = true;
    		GridView1.Enabled = true;
    			}
    		}
    
    	}
    	else if (objDs.Tables[0].Rows.Count == 0)
    	{
    		GridView1.DataSource = null;
    		GridView1.Visible = false;
    	}
    }
