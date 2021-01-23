    List<Student> listofStudents = new List<Student>();
    private void saveButton_Click(object sender, EventArgs e)
    {
        if (!listofStudents.Any(item => item.regNo == regNoTextBox.Text))
        {
            listofStudents.Add(new Student(firstNameTextBox.Text, lastNameTextBox.Text, regNoTextBox.Text));
            student.GetFullName();
        }
        regNoTextBox.Text = "";
        firstNameTextBox.Text = "";
        lastNameTextBox.Text = "";
    }
