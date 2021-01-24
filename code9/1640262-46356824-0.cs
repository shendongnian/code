    protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dr;
    
            dt.Columns.Add(new DataColumn("ColumnName1"));
            dt.Columns.Add(new DataColumn("ColumnName2"));
            dt.Columns.Add(new DataColumn("ColumnName3"));
    
            foreach (GridViewRow gvr in GridView1.Rows)
            {            
                if (((CheckBox)gvr.Cells[4].FindControl("CheckBox")).Checked == true)
                {
                    dr = dt.NewRow();
                    dr["ColumnName1"] = ((Label)gvr.Cells[0].FindControl("Label")).Text;
                    dr["ColumnName2"] = ((Label)gvr.Cells[1].FindControl("Label")).Text;
                    dr["ColumnName3"] = ((Label)gvr.Cells[2].FindControl("Label")).Text;
                    dt.Rows.Add(dr);
                }
            }
    
            foreach (GridViewRow gvr in GridView2.Rows)
            {
                dr = dt.NewRow();
                dr["ColumnName1"] = ((Label)gvr.Cells[0].FindControl("Label")).Text;
                dr["ColumnName2"] = ((Label)gvr.Cells[1].FindControl("Label")).Text;
                dr["ColumnName3"] = ((Label)gvr.Cells[2].FindControl("Label")).Text;
                dt.Rows.Add(dr);
            }
    
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
