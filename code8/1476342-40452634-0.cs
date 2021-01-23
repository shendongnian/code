    private void OnGridViewCustomDrawCell(object sender, RowCellCustomDrawEventArgs e) {
    	switch (e.Column.FieldName) {
    		case "Debit":
    			DrawDebitCell(e);
    			break;	
    	}		
    }
    
    private void DrawDebitCell(RowCellCustomDrawEventArgs e) {
    	e.Handled = true;
    	string text = string.Format(CultureInfo.CurrentCulture, "{0} {1:n2}", CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, e.CellValue);
    	Size textSize = e.Appearance.CalcTextSizeInt(e.Cache, text, int.MaxValue);
    	e.Appearance.DrawBackground(e.Cache, e.Bounds);
    	if (Convert.ToInt32(textSize.Width) > e.Bounds.Width)
    		e.Appearance.DrawString(e.Cache, text, e.Bounds);
    	else {
    		StringFormat stringFormat = e.Appearance.GetStringFormat();
    		string valueText = string.Format(CultureInfo.CurrentCulture, "{0:n2}", e.CellValue);
    		stringFormat.Alignment = StringAlignment.Near;
    		e.Appearance.DrawString(e.Cache, CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, e.Bounds, e.Appearance.Font, stringFormat);
    		stringFormat.Alignment = StringAlignment.Far;
    		e.Appearance.DrawString(e.Cache, valueText, e.Bounds, e.Appearance.Font, stringFormat);
    	}
    }
