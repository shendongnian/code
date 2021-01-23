    private void txt_marks_TextChanged(object sender, EventArgs e)
    {
    	string marks = Convert.ToString(txt_marks.Text);
    	string q_type = Convert.ToString(cmbQType.SelectedValue);
    	char[] q_types = { '[', ']', '%'};
    	
    	if (ContainsChars(q_types, q_type))
    	{
    		q_type = replacestring(q_type);
    	}
    	if (NoEmpty(btnlanguage.Text, txt_sub.Text, txt_std.Text, txt_marks.Text) && cmbQType.SelectedIndex != -1)
    	{
    		DataTable dt = main_ds.Tables[0];
    		dt.DefaultView.RowFilter = String.Format("Subject  Like '" + txt_sub.Text.ToString() + "%' and Standard Like '" + txt_std.Text.ToString() + "'and Chapter Like '" + btnlanguage.Text.ToString() + "%' and QuestionType Like '" + q_type + "' and Marks = '" + marks + "'");
    		DGV_View.DataSource = main_ds.Tables[0].DefaultView;
    	}
    	else if (NoEmpty(txt_marks.Text, txt_sub.Text, txt_std.Text) && cmbQType.SelectedIndex != -1)
    	{
    		DataTable dt = main_ds.Tables[0];
    		dt.DefaultView.RowFilter = String.Format("QuestionType Like '" + q_type + "' and  Marks = '" + marks + "' and Subject  Like '" + txt_sub.Text.ToString() + "%' and Standard Like '"+ txt_std.Text.ToString()+ "'");
    		DGV_View.DataSource = main_ds.Tables[0].DefaultView;
    	}
    
    	else if (NoEmpty(txt_marks.Text, txt_sub.Text) && cmbQType.SelectedIndex != -1)
    	{
    		DataTable dt = main_ds.Tables[0];
    		dt.DefaultView.RowFilter = String.Format("QuestionType Like '" + q_type + "' and  Marks = '" + marks + "' and Subject  Like '" + txt_sub.Text.ToString() + "%'");
    		DGV_View.DataSource = main_ds.Tables[0].DefaultView;
    	}
    	else if (txt_marks.Text != "" && cmbQType.SelectedIndex != -1)
    	{
    		DataTable dt = main_ds.Tables[0];
    		dt.DefaultView.RowFilter = String.Format(" QuestionType Like '" + q_type + "'  and Marks = '" + marks + "'");
    		DGV_View.DataSource = main_ds.Tables[0].DefaultView;
    	}
    	else if (txt_marks.Text != "")
    	{
    		DataTable dt = main_ds.Tables[0];
    		dt.DefaultView.RowFilter = String.Format("Marks = '"+ marks +"'");
    		DGV_View.DataSource = main_ds.Tables[0].DefaultView;
    	}
    	else
    	{
    		load_grid_view();
    	}
    }
    
    public static bool NoEmpty(params string[] strings)
    {
       return strings.All( x => x != string.Empty );
    }
    
    public static bool ContainsChars(IEnumerable<char> chars, string toTest)
    {
    	return chars.Any(x => toTest.Contains(x));
    }
