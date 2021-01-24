    private DataTable GetDT() {
      DataTable dt = new DataTable();
      dt.Columns.Add("Name", typeof(string));
      dt.Columns.Add("OrdinaryHours", typeof(double));
      dt.Columns.Add("HourlyWage", typeof(double));
      dt.Columns.Add("HolidayHours", typeof(double));
      dt.Columns.Add("CCSSDeductions", typeof(double));
      dt.Columns.Add("LoanDeductions", typeof(double));
      DataColumn dc = new DataColumn("Total", typeof(double));
      dc.Expression = "((OrdinaryHours * HourlyWage) + (HourlyWage * 2) * HolidayHours) - (CCSSDeductions + LoanDeductions)";
      dt.Columns.Add(dc);
      return dt;
    }
