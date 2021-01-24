    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType==DataControlRowType.DataRow)
            {
                System.Web.UI.HtmlControls.HtmlImage imageControl = (System.Web.UI.HtmlControls.HtmlImage)e.Row.FindControl("imageControl");
                if (((DataRowView)e.Row.DataItem)["imagedata"] != DBNull.Value)
                {
                    imageControl.Src = "data:image/png;base64," + Convert.ToBase64String((byte[])(((DataRowView)e.Row.DataItem))["imagedata"]);
                }
            }
        }
