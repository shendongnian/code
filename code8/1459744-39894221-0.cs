    protected void Button1_Click(object sender, EventArgs e)
    {
         DataTable dt = (DataTable)ViewState["Candidates"];
         dt.Rows.Add(TextBox1.Text.Trim(), TextBox2.Text.Trim(),TextBox3.Text.Trim());
         ViewState["Candidates"] = dt;
         TextBox1.Text = string.Empty;
         TextBox2.Text = string.Empty;
         TextBox3.Text = string.Empty;
         BindGrid();
    }
