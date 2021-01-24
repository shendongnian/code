    int startingRow = 0; // Row 1 in Excel is Row 0 in NPOI
	int endingRow = 4;
	StringBuilder builder = new StringBuilder();
	builder.Append("<table>");
	for (int r = startingRow; r < endingRow; r++)
	{	
		// Check if current row is null
		if (sheet1.GetRow(r) != null)
		{
			builder.Append("<tr>");
			
			// Get the current row
			IRow row = sheet1.GetRow(r);		
			
			// Loop through each cell in the row
			for (int c = 0; c < row.LastCellNum; c++)
			{
				builder.Append("<td>");
				
				// Check if current cell is null
				if (row.GetCell(c) != null)
				{					
					// Get cell value
					ICell cell = row.GetCell(c);
					
					// Append cell value between HTML table cells
					builder.Append(cell.ToString());
				}
				
				builder.Append("</td>");			
			}
			
			builder.Append("</tr>");
		}
	}
	builder.Append("</table>");
	// insert builder.ToString(); in your e-mail
