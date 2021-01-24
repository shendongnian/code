    protected void ExpToExcel_Click(object sender, EventArgs e)
    {
        // Get MyGridView control's HTML representation.
        var plainWriter = new StringWriter();
        var htmlWriter = new HtmlTextWriter(plainWriter);
        this.MyGridView.RenderControl(htmlWriter);
    
        // Load HTML into ExcelFile.
        SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
        var htmlOptions = new HtmlLoadOptions();
        var htmlStream = new MemoryStream(htmlOptions.Encoding.GetBytes(plainWriter.ToString()));
        var excel = ExcelFile.Load(htmlStream, htmlOptions);
    
        // Download ExcelFile to current HttpResponse.
        excel.Save(this.Response, "Enrollment_Major_Classification.xlsx");
    }
    
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* We're overriding this verification because of the "MyGridView.RenderControl" call.
         * This confirms that the "HtmlForm" control is rendered for "MyGridView" at run time. */
    }
