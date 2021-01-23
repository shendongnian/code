        var studentsList =Dictionary<string, Student>` for adding students with unique regNo:
        private void button1_Click(object sender, EventArgs e)
        {
            var regNo = regNoTextBox.Text;
            if(!studentsList.ContainsKey(regNo))
            {
                Student student = new Student();
                student.regNo = regNoTextBox.Text;
                student.firstName = firstNameTextBox.Text;
                student.lastName = LastNameTextBox.Text;
                student.GetFullName();
                studentsList.Add(regNo, student);
                regNoTextBox.Text = "";
                firstNameTextBox.Text = "";
                LastNameTextBox.Text = "";
                MessageBox.Show("Information Saved.");
            }        
            else
            {
                MessageBox.Show("The Reg.No already exists !");
            }
        }
