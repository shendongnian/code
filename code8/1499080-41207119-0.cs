    protected void Page_Load(object sender, EventArgs e)
    {
        // ...
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.Rows[i].Cells[4].Text == "industrial")
                GridView1.Rows[i].Visible = false;
        }
    }
