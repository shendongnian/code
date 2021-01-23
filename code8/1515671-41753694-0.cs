    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        Response.ClearContent();           
        Response.AppendHeader("content-disposition", "attachment; filename=Inventory.xls");
        Response.ContentType = "application/ms-excel";
        StringWriter stringWriter = new StringWriter();
        HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
        GridView1.DataBind();
        GridView1.RenderControl(htmlTextWriter);
        Response.Write(stringWriter.ToString());
        Response.End();
    }
