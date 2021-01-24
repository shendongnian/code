    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        LinkButton lnkButton = (LinkButton)e.Row.Cells[1].FindControl("lnkDownload");
                        HtmlImage img = (HtmlImage)e.Row.Cells[1].FindControl("imgData");
                        if (DataBinder.Eval(e.Row.DataItem, "ContentType").ToString().Contains("image"))//like image/jpeg
                        {
                            lnkButton.Visible = false;
                            img.Visible = true;
                            img.Src = "data:image/png;base64," + Convert.ToBase64String((byte[])DataBinder.Eval(e.Row.DataItem,"Data"));
                        }
                        else
                        {
                            lnkButton.Visible = true;
                            img.Visible = false;
                        }
                    }
                }
