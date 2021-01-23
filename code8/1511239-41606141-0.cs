        //after these lines
        rep.DataSource = ds.Tables;
        rep.DataBind();
        //add below lines:
        int count = 1;
        foreach (RepeaterItem item in rep.Items)
        {
            var grd = item.FindControl("grdVw") as GridView;
            grd.DataSource = ds.Tables[count - 1];
            grd.DataBind();
            count++;
        }
