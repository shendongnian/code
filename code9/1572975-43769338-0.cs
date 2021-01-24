    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        DataTable dt = new DataTable();
        dt.Columns.Add("Id");
        DataRow dr = dt.NewRow();
        dr["Id"] = 1;
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["Id"] = 2;
        dt.Rows.Add(dr);
        //To Export all pages
        grdTest.AllowPaging = false;
        grdTest.AllowSorting = false;
        grdTest.DataSource = dt;
        grdTest.DataBind();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdTest.RenderControl(hw); //here gridview is not rendering last row 
                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
    }
