	protected void Page_Load(object sender, EventArgs e)
	{
		Style escalated = new Style();
		escalated.ForeColor = System.Drawing.Color.Red;
		this.Page.Header.StyleSheet.CreateStyleRule(escalated, this, ".CssEscalated");
        Style rowStyle = new Style();
        rowStyle.BackColor = System.Drawing.Color.Red;
        this.Page.Header.StyleSheet.CreateStyleRule(rowStyle, this, ".CssRowStyle");
        Style cellStyle = new Style();
        cellStyle.BackColor = System.Drawing.Color.Aqua;
        this.Page.Header.StyleSheet.CreateStyleRule(cellStyle, this, ".CssCellStyle");
        Style highlightStyle = new Style();
        highlightStyle.BackColor = System.Drawing.Color.Yellow;
        this.Page.Header.StyleSheet.CreateStyleRule(highlightStyle, this, ".CssHighlightStyle");
    }
