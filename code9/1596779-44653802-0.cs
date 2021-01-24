    protected void Page_Load(object sender, EventArgs e)
    {
    if (!this.IsPostBack)
    {
        string fileName = Request.QueryString["pdffile"];
        string path = Server.MapPath("~/PDFs/") + fileName;
        Response.ContentType = "application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.WriteFile(path);
        Response.Flush();
        Response.End();
    }
    }
