        protected void gv1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int rowno = e.Row.DataItemIndex;
                //Suppose dt is DataTable to which you are binding your grid
                //and year is the column name within this datatable
                string year = Convert.ToString(dt.Rows[e.Row.DataItemIndex]["year"]);
                if (year == DateTime.Now.Year.ToString() || year == ((DateTime.Now.Year) - 1).ToString())
                {
                    LinkButton btedt = (LinkButton)e.Row.FindControl("btnedit");
                    LinkButton btdel = (LinkButton)e.Row.FindControl("btndel");
                    LinkButton btsm = (LinkButton)e.Row.FindControl("btnmail");
                    btdel.Visible = true;
                    btedt.Visible = true;
                    btsm.Visible = true;
                }
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    RadioButtonList rbtnlist = (RadioButtonList)e.Row.FindControl("rbtnlist");
                    DropDownList ddlist = (DropDownList)e.Row.FindControl("ddlyr");
                    for (int i = (DateTime.Now.Year); i >= ((DateTime.Now.Year) - 1); i--)
                    {
                        ddlist.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    }
                    ddlist.DataBind();
                    rbtnlist.DataBind();
                }
            }
