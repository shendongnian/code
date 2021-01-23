    List<Employee> lstEmployee = GetEmployeeList();
    dataGridView1.Rows.Clear();
 
    if (lstEmployee.Count == 0)
        return;
    
    foreach (var employee in lstEmployee)
    {
        DataGridViewRow dgvr = dataGridView1.Rows[dataGridView1.Rows.Add()];
        dgvr.Cells[colnId.Index].Value = employee.Id;
        dgvr.Cells[colnName.Index].Value = employee.Name;
        dgvr.Cells[colnGender.Index].Value = employee.Gender;
        dgvr.Cells[colnDepartmentId.Index].Value = employee.DepartmentId;
        dgvr.Cells[colnSalary.Index].Value = employee.Salary.GetSalaryString();
    }
