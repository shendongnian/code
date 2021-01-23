     private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                int j;
                for (i = 0; i < Main.studentList.Count; i++)
                {
                    if (comboBox1.SelectedItem == Main.studentList[i].StudentName + " " + Main.studentList[i].StudentId)
                    {  
        j=i;                
                        break;
                    }
        
                }
        
                txtName.Text = Main.studentList[j].StudentName; //where the error occurs
        
            }
        
            public void ChangeStudent_Load(object sender, EventArgs e)
            {
                //loading combobox from studentList
                foreach (var student in Main.studentList)
                {
                    comboBox1.Items.Add(student.StudentName + " " + student.StudentId);
        
                }
            }
