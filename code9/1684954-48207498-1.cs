     protected void GridView1_DataBound(object sender, EventArgs e)
    {
        for (int i =0 ; i <= GridView1.Rows.Count -1 ;i++)
        {
            Label lblparent = (Label)GridView1.Rows[i].FindControl("Label1");
            if (lblparent.Text == "1")
            {
                GridView1.Rows[i].Cells[6].BackColor = Color.Yellow;
                lblparent.ForeColor = Color.Black;
            }
            else
            {
                GridView1.Rows[i].Cells[6].BackColor = Color.Green;
                lblparent.ForeColor = Color.Yellow;
            }
                
        }
    }
