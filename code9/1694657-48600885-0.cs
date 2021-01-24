            DataRow dr = null;
            dtResult.Columns.Add(new DataColumn("mainevent",typeof(string)));
    
            dtResult.Columns["mainevent"].Expression = "'Round Data'";
            dr = dt.Result.NewRow();
            DataRow dr2 = dt.Result.NewRow();
            foreach (GridViewRow gr in grdOther.Rows)
            {
                dr = dtResult.NewRow();
                dr2 = dtResult.NewRow();
                TextBox box1 = (TextBox)gr.Cells[1].FindControl("txtmainevent");
                TextBox box2 = (TextBox)gr.Cells[2].FindControl("txtse");
                dr["mainevent"] = box1.Text;
                dr2["mainevent"] = box2.Text;
                dtResult.Rows.Add(dr);dtResult.Rows.Add(dr2);
            }
