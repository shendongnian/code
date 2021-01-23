    //public class MyDataGridTextBoxColumn : DataGridTextBoxColumn
    protected override object GetColumnValueAtRow(CurrencyManager source, int rowNum)
    {
        var value = base.GetColumnValueAtRow(source, rowNum);
        return FormatValue(value);
    }
