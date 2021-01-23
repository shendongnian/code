    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i;
        for (i = 0; i < Main.studentList.Count; i++)
        {
            if (comboBox1.SelectedItem == Main.studentList[i].StudentName + " " + Main.studentList[i].StudentId)
            {              
                txtName.Text = Main.studentList[i].StudentName; 
                break;
            }
        }
    }
