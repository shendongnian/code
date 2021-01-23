    public string ConvertDataGridViewToHTMLWithFormatting(DataGridView dgv)
    {
    	StringBuilder sb = new StringBuilder();
    	//create html & table
    	sb.AppendLine("<html><body><center><table border='1' cellpadding='0' cellspacing='0'>");
    	sb.AppendLine("<tr>");
    	//create table header
    	for (int i = 0; i < dgv.Columns.Count; i++)
    	{
    		//Set the Alignment and BackColour
    		sb.AppendLine(DGVCellToHTMLWithFormatting(dgv,i,j));
    		sb.AppendLine(dgv.Columns[i].HeaderText);
    		sb.AppendLine("</td>");
    	}
    	sb.AppendLine("</tr>");
    	//create table body
    	for (int i = 0; i < dgv.Rows.Count; i++)
    	{
    		sb.AppendLine("<tr>");
    		foreach (DataGridViewCell dgvc in dgv.Rows[i].Cells)
    		{
    			//Set the Alignment and BackColour
    			sb.AppendLine(DGVCellToHTMLWithFormatting(dgv,i,j));
    			sb.AppendLine(dgvc.Value.ToString());
    			sb.AppendLine("</td>");
    		}
    		sb.AppendLine("</tr>");
    	}
    //table footer & end of html file
    sb.AppendLine("</table></center></body></html>");
    return sb;
    } 
    
    public string DGVCellToHTMLWithFormatting(DataGridView dgv, int row, int col)
    {
    	sb.AppendLine("<td");
    	sb.AppendLine(DGVCellColorToHTML(dgv.Rows[row].Cells[col].Style.SelectionBackColor));
    	sb.AppendLine(DGVCellAlignmentToHTML(dgv.Rows[row].Cells[col].Style.Alignment));
    	sb.AppendLine(">");
    }
    
    public string DGVCellColorToHTML(Color color)
    {
    	if (color == Color.White || color == Color.Transparent) return string.Empty;
    	
    	StringBuilder sb = new StringBuilder();
    	sb.AppendLine(" backcolor='#");
    	sb.AppendLine(color.ToHex());
    	sb.AppendLine("'");
    	return sb.ToString()
    }
    
    public string DGVCellAlignmentToHTML(DataGridViewContentAlignment align)
    {
    	if (align == DataGridViewContentAlignment.MiddleCenter) return string.Empty;
    
    	string horizontalAlignment = string.Empty; 
    	string verticalAlignment = string.Empty;
    	CellAlignment(dataGridView1.Rows[row].Cells[col].Style.Alignment, ref horizontalAlignment, ref verticalAlignment);
    	StringBuilder sb = new StringBuilder();
    	sb.AppendLine(" align='");
    	sb.AppendLine(horizontalAlignment);
    	sb.AppendLine("' valign='");
    	sb.AppendLine(verticalAlignment);
    	sb.AppendLine("'");
    	return sb.ToString();
    }
    
    private void CellAlignment(DataGridViewContentAlignment  align, ref string horizontalAlignment, ref string verticalAlignment)
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
    
    		default:
    			horizontalAlignment = "left";
    			verticalAlignment = "middle";
    			break;
    	}
    }
    
