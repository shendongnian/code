     public Student CreateModel()
        {
            Student model = new Student
            {
                Name = nameTextBox.Text,
                Phone = phoneTextBox.Text,
                DepartmentId = departmentComboBox.SelectedValue.ToString(),                
            };
            model.SetCommonValues();
            return model;
        }
