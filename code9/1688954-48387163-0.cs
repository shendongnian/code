    public ExcelRangeBase LoadFromText(string Text, ExcelTextFormat Format, TableStyles TableStyle, bool FirstRowIsHeader)
    {
    	ExcelRangeBase excelRangeBase = this.LoadFromText(Text, Format);
    	ExcelTable excelTable = this._worksheet.Tables.Add(excelRangeBase, "");
    	excelTable.ShowHeader = FirstRowIsHeader;
    	excelTable.TableStyle = TableStyle;
    	return excelRangeBase;
    }
