    private void OnCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == this.columnValue.Index)
        {
            if (e.Value == null)
            {   // show the Null value:
                e.Value = e.CellStyle.NullValue;
                e.FormattingApplied = true;
            }
			else
			{   // because validated I know value is a decimal:
                decimal value = Decimal.Parse((string)e.Value);
                e.Value = value.ToString(e.CellStyle.Format);
                e.FormattingApplied = true;
            }
            // If desired apply other formatting, like background colouring etc
        }
    }
