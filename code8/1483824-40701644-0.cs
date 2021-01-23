    List<Student>studentslist=new List<Student>();
    public Student student;        
    //Save Button
    private void button1_Click(object sender, EventArgs e)
    {
        Student student = new Student();
        student.regNo = regNoTextBox.Text;
        student.firstName = firstNameTextBox.Text;
        student.lastName = LastNameTextBox.Text;
        student.GetFullName();
        Student s=studentlists.Where(item=>item.regNo==textbox_regNumber).FirstorDefault();
        if(s!==null)
        {
            studentslist.Add(student);
            regNoTextBox.Text = "";
            firstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            MessageBox.Show("Information Saved.");
        }
        else
        {
            MessageBox.Show("The Reg.No is alresy exist !");
        }
    }
