        protected void AllUsersGridView_RowDataBound1(object sender, GridViewRowEventArgs e)
                    {
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
            
                            LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
                            LinkButton LinkButton2 = (LinkButton)e.Row.FindControl("LinkButton2");
            
                            CheckBox c = ((CheckBox)e.Row.FindControl("idOfCheckBox");
                            LinkButton1.Visible = LinkButton2.Visible = c.Checked
                        }
                    }
