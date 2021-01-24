    private void lowestGrade_Click(object sender, EventArgs e) {
        // this probably only needs to be sorted if a value is added or removed (addStudent_Click)           
         Array.Sort(grade, name); 
         outputText.Visible = true;
         // first element (with index 0) will be the lowest because arrays are sorted now
         outputText.Text = name[0] + "  " + grade[0]; 
     }
