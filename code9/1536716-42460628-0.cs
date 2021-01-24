    if (!DT.Columns.Contains("dateX")) DT.Columns.Add("dateX", typeof(DateTime));
    foreach (DataRow row in DT.Rows)
        row.SetField<DateTime>("dateX", DateTime.Now.Date.AddMonths(row.Field<int>("c1")));
    Series s = chart1.Series[0];
    s.XValueMember = "dateX";
    s.XValueType = ChartValueType.DateTime;
    s.YValueMembers = "c2";
    chart1.DataSource = DT;
    chart1.DataBind();
    Axis ax = chart1.ChartAreas[0].AxisX;
    ax.LabelStyle.Format = "MMMM" ;
    ax.IntervalType = DateTimeIntervalType.Months;
    ax.Interval = 1;
