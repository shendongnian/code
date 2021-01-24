            Dal run = new Dal();
            protected void TextBox1_TextChanged(object sender, EventArgs e)
            {
               SetLabel1Text(TextBox1.Text);         
            }
            protected void TextBox2_TextChanged(object sender, EventArgs e)
            {
                string query2 = string.Format("select * From profile where id={0}", TextBox2.Text);
                DataTable dt2 = new DataTable();
                dt2 = run.withquery(query2);
                Label2.Text = dt2.Rows[0]["profile"].ToString();
            }
            protected void btn_Click(object sender, EventArgs e)
            {
                string query3 = string.Format("select * From Db where id={0}", "1369");
                DataTable dt3 = new DataTable();
                dt3 = run.withquery(query3);
                TextBox1.Text = dt3.Rows[0]["1"].ToString();
                TextBox2.Text = dt3.Rows[0]["2"].ToString();
                TextBox3.Text = dt3.Rows[0]["3"].ToString();
    
                SetLabel1Text(TextBox1.Text);
            }
            public void SetLabel1Text(string txtText)
            {
                string query1 = string.Format("select * From user where id={0}", txtText);
                DataTable dt1 = new DataTable();
                dt1 = run.withquery(query1);
                Label1.Text = dt1.Rows[0]["name"].ToString();
            }
