    //Show Columns in Title, Lower(textInfo.ToLowerCase) or Upper case textInfo.ToUpperCase
    	System.Globalization.TextInfo textInfo = new System.Globalization.CultureInfo("en-US", false).TextInfo;
    	foreach (DataGridViewColumn col in dataGridView.Columns)
        {
    		col.HeaderText = textInfo.ToTitleCase(col.HeaderText);
        }
    
    //Customize specific column headers, using name or column index	
    	dataGridView.Columns["number"].HeaderText = "No.";
    	dataGridView.Columns["quantity"].HeaderText = "Product Quantity";
    	dataGridView.Columns[0].HeaderText = "Code";	
    	
    //Set Row headers with numbers   
    	int rowNumber = 1;
        foreach (DataGridViewRow row in dataGridView.Rows)
        {
            if (row.IsNewRow) continue;
            row.HeaderCell.Value = "Row " + rowNumber;
            rowNumber = rowNumber + 1;
        }
        dataGridView.AutoResizeRowHeadersWidth(
        DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
