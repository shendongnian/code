    private void buttonEdit_Click(object sender, EventArgs e)
    {
        // Get the selected employee from the listBox and cast it to EmployeeClass.
        var employee = (EmployeeClass)listBoxEmployees.SelectedItem;
    
        if (employee != null) { // An employee has been selected.
             // Use the new C# 7.0 switch syntax in order to swich by employee type.
            switch (employee) {
                case SalariedEmployee sEmployee:
                    var frm = new Salary_Employee(); // Open the salaried employee form..
                    frm.employeeEntry = sEmployee;
                    frm.Show();
                    break;
                case HourlyEmployee hEmployee:
                    var frm = new Hourly_Employee(); // Open the hourly employee form.
                    frm.employeeEntry = hEmployee;
                    frm.Show();
                    break;
            }
        }
    }
