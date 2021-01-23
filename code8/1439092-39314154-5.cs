    //====================================================
    //DataGridView Export To HTML by Jeremy Thompson: http://stackoverflow.com/questions/39210329/
    //====================================================
    public string ConvertDataGridViewToHTMLWithFormatting(DataGridView dgv)
    {
    	StringBuilder sb = new StringBuilder();
    	//create html & table
    	sb.AppendLine("<html><body><center><table border='1' cellpadding='0' cellspacing='0'>");
    	sb.AppendLine("<tr>");
    	//create table header
    	for (int i = 0; i < dgv.Columns.Count; i++)
    	{
    		sb.Append(DGVHeaderCellToHTMLWithFormatting(dgv, i));
    		sb.Append(DGVCellFontAndValueToHTML(dgv.Columns[i].HeaderText, dgv.Columns[i].HeaderCell.Style.Font));
    		sb.AppendLine("</td>");
    	}
    	sb.AppendLine("</tr>");
    	//create table body
    	for (int rowIndex = 0; rowIndex < dgv.Rows.Count; rowIndex++)
    	{
    		sb.AppendLine("<tr>");
    		foreach (DataGridViewCell dgvc in dgv.Rows[rowIndex].Cells)
    		{
    			sb.AppendLine(DGVCellToHTMLWithFormatting(dgv, rowIndex, dgvc.ColumnIndex));
    			string cellValue = dgvc.Value == null ? string.Empty : dgvc.Value.ToString();
    			sb.AppendLine(DGVCellFontAndValueToHTML(cellValue, dgvc.Style.Font));
    			sb.AppendLine("</td>");
    		}
    		sb.AppendLine("</tr>");
    	}
    	//table footer & end of html file
    	sb.AppendLine("</table></center></body></html>");
    	return sb.ToString();
    }
    
    //TODO: Add more cell styles described here: https://msdn.microsoft.com/en-us/library/1yef90x0(v=vs.110).aspx
    public string DGVHeaderCellToHTMLWithFormatting(DataGridView dgv, int col)
    {
    	StringBuilder sb = new StringBuilder();
    	sb.Append("<td");
    	sb.Append(DGVCellColorToHTML(dgv.Columns[col].HeaderCell.Style.ForeColor, dgv.Columns[col].HeaderCell.Style.BackColor));
    	sb.Append(DGVCellAlignmentToHTML(dgv.Columns[col].HeaderCell.Style.Alignment));
    	sb.Append(">");
    	return sb.ToString();
    }
    
    public string DGVCellToHTMLWithFormatting(DataGridView dgv, int row, int col)
    {
    	StringBuilder sb = new StringBuilder();
    	sb.Append("<td");
    	sb.Append(DGVCellColorToHTML(dgv.Rows[row].Cells[col].Style.ForeColor, dgv.Rows[row].Cells[col].Style.BackColor));
    	sb.Append(DGVCellAlignmentToHTML(dgv.Rows[row].Cells[col].Style.Alignment));
    	sb.Append(">");
    	return sb.ToString();
    }
    
    public string DGVCellColorToHTML(Color foreColor, Color backColor)
    {
    	if (foreColor.Name == "0" && backColor.Name == "0") return string.Empty;
    
    	StringBuilder sb = new StringBuilder();
    	sb.Append(" style=\"");
    	if (foreColor.Name != "0" && backColor.Name != "0")
    	{
    		sb.Append("color:#");
    		sb.Append(foreColor.R.ToString("X2") + foreColor.G.ToString("X2") + foreColor.B.ToString("X2"));
    		sb.Append("; background-color:#");
    		sb.Append(backColor.R.ToString("X2") + backColor.G.ToString("X2") + backColor.B.ToString("X2"));
    	}
    	else if (foreColor.Name != "0" && backColor.Name == "0")
    	{
    		sb.Append("color:#");
    		sb.Append(foreColor.R.ToString("X2") + foreColor.G.ToString("X2") + foreColor.B.ToString("X2"));
    	}
    	else //if (foreColor.Name == "0" &&  backColor.Name != "0")
    	{
    		sb.Append("background-color:#");
    		sb.Append(backColor.R.ToString("X2") + backColor.G.ToString("X2") + backColor.B.ToString("X2"));
    	}
    
    	sb.Append(";\"");
    	return sb.ToString();
    }
    
    public string DGVCellFontAndValueToHTML(string value,Font font)
    {
    	//If no font has been set then assume its the default as someone would be expected in HTML or Excel
    	if (font == null || font == this.Font && !(font.Bold | font.Italic | font.Underline | font.Strikeout)) return value;
    	StringBuilder sb = new StringBuilder();
    	sb.Append(" ");
    	if (font.Bold) sb.Append("<b>");
    	if (font.Italic) sb.Append("<i>");
    	if (font.Strikeout) sb.Append("<strike>");
    	
    	//The <u> element was deprecated in HTML 4.01. The new HTML 5 tag is: text-decoration: underline
    	if (font.Underline) sb.Append("<u>");
    	
    	string size = string.Empty;
    	if (font.Size != this.Font.Size) size = "font-size: " + font.Size + "pt;";
    
    	//The <font> tag is not supported in HTML5. Use CSS or a span instead. 
    	if (font.FontFamily.Name != this.Font.Name)
    	{
    		sb.Append("<span style=\"font-family: ");
    		sb.Append(font.FontFamily.Name);
    		sb.Append("; ");
    		sb.Append(size);
    		sb.Append("\">");
    	}
    	sb.Append(value);
    	if (font.FontFamily.Name != this.Font.Name) sb.Append("</span>");
    
    	if (font.Underline) sb.Append("</u>");
    	if (font.Strikeout) sb.Append("</strike>");
    	if (font.Italic) sb.Append("</i>");
    	if (font.Bold) sb.Append("</b>");
    
    	return sb.ToString();
    }
    
    public string DGVCellAlignmentToHTML(DataGridViewContentAlignment align)
    {
    	if (align == DataGridViewContentAlignment.NotSet) return string.Empty;
    
    	string horizontalAlignment = string.Empty;
    	string verticalAlignment = string.Empty;
    	CellAlignment(align, ref horizontalAlignment, ref verticalAlignment);
    	StringBuilder sb = new StringBuilder();
    	sb.Append(" align='");
    	sb.Append(horizontalAlignment);
    	sb.Append("' valign='");
    	sb.Append(verticalAlignment);
    	sb.Append("'");
    	return sb.ToString();
    }
    
    private void CellAlignment(DataGridViewContentAlignment align, ref string horizontalAlignment, ref string verticalAlignment)
    {
    	switch (align)
    	{
    		case DataGridViewContentAlignment.MiddleRight:
    			horizontalAlignment = "right";
    			verticalAlignment = "middle";
    			break;
    		case DataGridViewContentAlignment.MiddleLeft:
    			horizontalAlignment = "left";
    			verticalAlignment = "middle";
    			break;
    		case DataGridViewContentAlignment.MiddleCenter:
    			horizontalAlignment = "centre";
    			verticalAlignment = "middle";
    			break;
    		case DataGridViewContentAlignment.TopCenter:
    			horizontalAlignment = "centre";
    			verticalAlignment = "top";
    			break;
    		case DataGridViewContentAlignment.BottomCenter:
    			horizontalAlignment = "centre";
    			verticalAlignment = "bottom";
    			break;
    		case DataGridViewContentAlignment.TopLeft:
    			horizontalAlignment = "left";
    			verticalAlignment = "top";
    			break;
    		case DataGridViewContentAlignment.BottomLeft:
    			horizontalAlignment = "left";
    			verticalAlignment = "bottom";
    			break;
    		case DataGridViewContentAlignment.TopRight:
    			horizontalAlignment = "right";
    			verticalAlignment = "top";
    			break;
    		case DataGridViewContentAlignment.BottomRight:
    			horizontalAlignment = "right";
    			verticalAlignment = "bottom";
    			break;
    
    		default: //DataGridViewContentAlignment.NotSet
    			horizontalAlignment = "left";
    			verticalAlignment = "middle";
    			break;
    	}
    }
    //Easy repro - copy/paste all this code in a Winform app!
    private void Form1_Load(object sender, EventArgs e)
    {
    	string configFile = System.IO.Path.Combine(Application.StartupPath.Replace("\\bin\\Debug", ""), "testData.csv");
    	List<string[]> rows = System.IO.File.ReadAllLines(configFile).Select(x => x.Split(',')).ToList();
    
    	DataTable dataTable = new DataTable();
    	dataTable.Columns.Add("testing");
    	dataTable.Columns.Add("one");
    	dataTable.Columns.Add("two");
    	dataTable.Columns.Add("three");
    	rows.ForEach(x => { dataTable.Rows.Add(x); });
    	this.dgv.DataSource = dataTable;
    
    	dgv.Columns[0].HeaderCell.Style.Font = new Font(this.Font, FontStyle.Strikeout); 
    
    	dgv[0, 0].Style.BackColor = Color.Aqua;
    	dgv[1, 0].Style.Alignment = DataGridViewContentAlignment.BottomRight;
    	dgv[2, 0].Style.Font = new Font(new FontFamily("Calibri"),(float)16);
    	dgv[3, 0].Style.ForeColor = Color.Red;
    	
    	dgv[0, 1].Style.Font = new Font(this.Font, FontStyle.Bold);
    	dgv[1, 1].Style.Font = new Font(this.Font,  FontStyle.Underline);
    	dgv[2, 1].Style.Font = new Font(this.Font, FontStyle.Italic);
    	dgv[3, 1].Style.Font = new Font(this.Font, FontStyle.Bold | FontStyle.Underline);
    	dgv[3, 1].Style.ForeColor = Color.Green;
    	dgv[3, 1].Style.BackColor = Color.Yellow;
    
    	dgv[0, 2].Style.Font = new Font(new FontFamily("Times New Roman"), (float)18);
    	dgv[1, 2].Style.Font = new Font(new FontFamily("Georgia"), (float)12);
    	dgv[2, 2].Style.Font = new Font(new FontFamily("Arial"), (float)14);
    	dgv[3, 2].Style.Font = new Font(new FontFamily("Verdana"), (float)18);
    
    	dgv[0, 3].Style.Font = new Font(new FontFamily("Courier New"), (float)11);
    	dgv[1, 3].Style.Font = new Font(new FontFamily("Lucida Console"), (float)18);
    	dgv[2, 3].Style.Font = new Font(new FontFamily("Times"), (float)14);
    	dgv[3, 3].Style.Font = new Font(new FontFamily("serif"), (float)12);
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
    	string dgvToHTMLTable = ConvertDataGridViewToHTMLWithFormatting(dgv);
        Clipboard.SetText(dgvToHTMLTable);
    }
    
