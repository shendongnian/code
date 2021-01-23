    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
           // Grid_bindExcel();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=Category.xls");
            Response.ContentType = "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);
            Label lblheader = new Label();
            lblheader.Font.Size = 14;
            lblheader.Font.Bold = true;
            lblheader.Text = "Category Detail";
            lblheader.RenderControl(hw);
    
            GrdExcel.Visible = true;
            GrdExcel.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
            GrdExcel.Visible = false;
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    
    }
