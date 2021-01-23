     protected void Button1_Click(object sender, EventArgs e)
            {
                DataTable dt = (DataTable)ViewState["Candidates"];
                dt.Rows.Add(TextBox1.Text.Trim(), TextBox2.Text.Trim(),TextBox3.Text.Trim());
           -
                TextBox1.Text = string.Empty;
                TextBox2.Text = string.Empty;
                TextBox3.Text = string.Empty;
    
            }
    
            protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
            {
    
            }
            protected void BindGrid()
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        
        }
    }
