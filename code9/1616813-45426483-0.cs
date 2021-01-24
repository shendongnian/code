    private void comboBoxUniversity_SelectedIndexChanged(object sender, EventArgs e)
    {
        comboBoxCourse.DisplayMember = "name_Course";
        comboBoxCourse.DataSource = valuesComboBoxes.GetUnidade(comboBoxUniversity.Text);
        comboBoxCourse.Update();
    }
    private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        comboBoxClasses.DisplayMember = "name_Classes";
        comboBoxClasses.DataSource = valuesComboBoxes.GetClasses(comboBoxUniversity.Text, comboBoxCourse.Text);
        comboBoxClasses.Update();
    }
