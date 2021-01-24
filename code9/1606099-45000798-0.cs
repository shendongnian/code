    PayrollItem[] it = GetPayrollItems(xmlResult);
        foreach (var inv in it)
        {
            DataRow row = ResultsTable.NewRow();
            row["EmployeeKey"] = inv.BadgeNo;
            row["StoreKey"] = inv.CostCentre;
            row["EmployeeName"] = inv.EmpName;
            row["DateKey"] = inv.Date;
            row["Incheck"] = inv.In;
            row["Outcheck"] = inv.Out;
            System.Diagnostics.Debug.WriteLine("inv.BadgeNo {0} i StoreKey {1}", inv.EmpName, inv.CostCentre);
            ResultsTable.Rows.Add(row);
            
        }
    return ResultsTable;
