    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "StudentDetail.xls"));
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;
            System.IO.StringWriter writer = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter html = new System.Web.UI.HtmlTextWriter(writer);
            dlstudent.DataBind();
            dlstudent.RenderControl(html);
            Response.Write(writer.ToString());
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
        }
    }
