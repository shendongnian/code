	protected void Page_Load(object sender, EventArgs e)
	{
        Style cellStyle = new Style();
        cellStyle.BackColor = System.Drawing.Color.Red;
        this.Page.Header.StyleSheet.CreateStyleRule(escalated, this, ".CsscellStyle");
    }
