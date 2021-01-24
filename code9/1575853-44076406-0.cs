        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                gvs.SetHeaderArrows(e);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int Id = (int)(e.Row.RowIndex);
                int? inspID = convert.ToIntQ(DataBinder.Eval(e.Row.DataItem, "InspectionID"));
                string rowclicked = string.Format("clickedrow{0}", Id);
                if (convert.ToIntQ(Session[rowclicked]) != null)
                {
                    if (Id == Convert.ToInt32(Session[rowclicked]))
                    {
                        LinkButton button = (LinkButton) e.Row.FindControl("lnkbtnView");
                        button.ForeColor = Color.Gray;
                        button.Enabled = false;
                    }
                    else
                    {
                        LinkButton button = (LinkButton)e.Row.FindControl("lnkbtnView");
                        button.ForeColor = Color.DarkBlue;
                        button.Enabled = true;
                    }
                }
