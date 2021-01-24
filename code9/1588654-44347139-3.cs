    private void buttonEdit_Click(object sender, EventArgs e)
    {
        // Get the selected employee from the listBox.
        object employee = listBoxEmployees.SelectedItem;
    
        if (employee != null) { // An employee has been selected.
             // Use the new C# 7.0 switch syntax in order to switch by employee type.
            switch (employee) {
                case SalariedEmployee sEmployee:
                    var sfrm = new Salary_Employee(); // Open the salaried employee form..
                    sfrm.employeeEntry = sEmployee;
                    sfrm.Show();
                    break;
                case HourlyEmployee hEmployee:
                    var hfrm = new Hourly_Employee(); // Open the hourly employee form.
                    hfrm.employeeEntry = hEmployee;
                    hfrm.Show();
                    break;
            }
        }
    }
