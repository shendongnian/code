    //// use this condition if you don't have that column in your data-source
    if (dataGridView.Columns.Contains("Final_Amount") == false)
    {
        dataGridView.Columns.Add("Final_Amount", "Final Amount");
    }
    dataGridView.Refresh();
    //// I extract indexes of my needed columns
    var colIndexFinalAmount = dataGridView.Columns["Final_Amount"].Index;
    //// when you know `DataPropertyName` of the column instead of its name use a way like this
    var colIndexBasicSalary = dataGridView.Columns.OfType<DataGridViewColumn>().SingleOrDefault(w=> w.DataPropertyName == "Basic_Salary").Index;
    var colIndexWorkingDays = dataGridView.Columns.OfType<DataGridViewColumn>().SingleOrDefault(w => w.DataPropertyName == "WorkingDays").Index;
    var colIndexYearNo = dataGridView.Columns.OfType<DataGridViewColumn>().SingleOrDefault(w => w.DataPropertyName == "YearNo").Index;
    var colIndexMonthNo = dataGridView.Columns.OfType<DataGridViewColumn>().SingleOrDefault(w => w.DataPropertyName == "MonthNo").Index;
    //// using a simple for is better in this situation    
    for (var i = 0; i < dataGridView.RowCount - 1; i++)
    {
        //// extract values from your cells but in an expected type (mine is double as my final amount will be double)
        var bs = double.Parse(dataGridView.Rows[i].Cells[colIndexBasicSalary].Value.ToString());
        var wd = double.Parse(dataGridView.Rows[i].Cells[colIndexWorkingDays].Value.ToString());
        //// A way of getting days of a month is this:
        var yn = int.Parse(dataGridView.Rows[i].Cells[colIndexYearNo].Value.ToString());
        var mn = int.Parse(dataGridView.Rows[i].Cells[colIndexMonthNo].Value.ToString());
        var md = (double)DateTime.DaysInMonth(yn, mn);
        //// now, just calculate what you want and set it as `Value` like this:
        dataGridView.Rows[i].Cells[colIndexFinalAmount].Value = bs / md * wd;
    }
