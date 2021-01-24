       List<Employee> employees = new List<Employee>(); // make this global to the class
        
        private void addEmployee_Click(object sender, EventArgs e)
        {
            employees.Add(new Employee()
            {
                egn = egnInput.Text,
                names = namesInput.Text,
                proffesion = professionList.Text,
                office = officeList.Text,
                salary = Double.Parse(salaryInput.Text),
                joinDate = DateTime.Parse(joinDatePicker.Text)
            });
    
            MessageBox.Show("Служителя бе добавен успешно!");
    
            egnInput.Clear();
            namesInput.Clear();
            professionList.Text = "";
            officeList.Text = "";
            salaryInput.Clear();
            joinDatePicker.Text = "";
    
        }
