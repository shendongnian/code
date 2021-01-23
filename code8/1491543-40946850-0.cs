    private void bindStudent(Student student) {
        if (student != null) {
            txtFirstName.Text = student.FirstName;
            txtLastName.Text = student.LastName;
            txtCity.Text = student.City;
        }
        else { // Just a fail-safe.
            txtFirstName.Clear();
            txtLastName.Clear();
            txtCity.Clear();
        }
    }
