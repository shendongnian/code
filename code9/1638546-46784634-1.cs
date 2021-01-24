    VB.net:
	 Dim hitInfo = GridView1.CalcHitInfo(e.Location)  
	If e.Button = Windows.Forms.MouseButtons.Left Then 
        For Each column As GridColumn In GridView1.Columns  
           If column.FieldName = hitInfo.Column.FieldName Then 
                hitInfo.Column.AppearanceCell.BackColor = Color.FromArgb(226, 234, 253)                       
           Else
                GridView1.Columns(column.FieldName).AppearanceCell.BackColor = Nothing
           End If
        Next
    End If
	
     C#: 
    var hitInfo = GridView1.CalcHitInfo(e.Location);
    if (e.Button == Windows.Forms.MouseButtons.Left) 
	{
	    foreach (GridColumn column in GridView1.Columns) 
		{
		   if (column.FieldName == hitInfo.Column.FieldName) 
		    {
			    hitInfo.Column.AppearanceCell.BackColor = Color.FromArgb(226, 234, 253);
		    }
		    else 
		    {
			GridView1.Columns(column.FieldName).AppearanceCell.BackColor = null;
		    }
	    }
    }
