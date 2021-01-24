    Student student = new Student();
    Lecturer lecturer = new Lecturer();
    string line = string.Empty;
        using (StreamReader login = new StreamReader("login.txt"))
        {
           while ((line = login.ReadLine()) != null)
            {
              if (line.StartsWith("Lecturer Username:"))
                 {
                   lecturer.Username = line.Substring(line.LastIndexOf(':') + 1).Trim();
                 }
              else if (line.StartsWith("Lecturer Password:"))
                 {
                        lecturer.Password = line.Substring(line.LastIndexOf(':') + 1).Trim();
                 }
              else if (line.StartsWith("Student Username:"))
                 {
                      student.Username = line.Substring(line.LastIndexOf(':') + 1).Trim();
                 }
              else if (line.StartsWith("Student Password:"))
                 {
                    student.Password = line.Substring(line.LastIndexOf(':') + 1).Trim();
                 }
             }
           }
         if (txtUserName.Text == lecturer.Username&& txtPassword.Text == lecturer.Password)
            {
                   lecturer.Show();
            }
         else if (txtUserName.Text == student.Username && txtPassword.Text == student.Username)
            {
                    student.Show();
            }
         else
           {
                    MessageBox.Show("Inccorect User Name or Password, please enter the correct credentials");
            }
