    protected void Button1_Click(object sender, EventArgs e) {  
            string str = txtname.Text.Trim();  
            string str1 = TextBox1.Text.Trim();  
            dt = (DataTable) ViewState["Details"];  
            dt.Rows.Add(str, str1);  
            ViewState["Details"] = dt;  
            GridView1.DataSource = dt;  
            GridView1.EmptyDataText = "Name";  
            GridView1.EmptyDataText = "Address";  
            GridView1.DataBind();  
        }
