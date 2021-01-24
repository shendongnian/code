    public void studentsToList()
    {
        ListBox items = new ListBox();
        for (int x = 0; x < students.Count; x++)
        {
            StudentListItem roundItem = new StudentListItem();
            roundItem.uc_txtStudentNumber.Content += Convert.ToString(students[x].Student_Number);
            roundItem.uc_txtSurname.Content += Convert.ToString(students[x].Student_Name);
            roundItem.uc_txtSurname.Content += Convert.ToString(students[x].Student_Gender);
            items.Items.Add(roundItem);
        }
    }
