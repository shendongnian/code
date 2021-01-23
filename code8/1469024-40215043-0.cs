    DataTable dtt = new DataTable();
    dtt.Columns.Add("UserId", typeof(int));
    dtt.Columns.Add("FullName", typeof(string));
    dtt.Columns.Add("EmployeeCode ", typeof(string));
    foreach(var employee in empList1)
       dtt.Rows.Add(employee.UserId, employee.FullName, employee.EmployeeCode);
