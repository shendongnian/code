     private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
            {
                // execute some code
    
                var student = (Student)((System.Windows.Controls.DataGridRow)sender).Item;
    
                MessageBox.Show("RollNo = " + student.RollNo + " Name = " + student.marks + " marks = " + student.marks);
            }
