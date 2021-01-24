    private void cb1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if((int)cb1.SelectedValue == 0)
        {
            cb2.DataSource = new List<ComboBoxItem> { new ComboBoxItem() { Text = "select course", Value = 0 } };
            cb3.DataSource = new List<ComboBoxItem> { new ComboBoxItem() { Text = "select class", Value = 0 } };
        }
        else
        {
            cb2.DataSource = GetCoursesForUniversity((int)cb1.SelectedValue);
            cb3.DataSource = new List<ComboBoxItem> { new ComboBoxItem() { Text = "select class", Value = 0 } };
        }
    }
    private void cb2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((int)cb1.SelectedValue == 0)
        {
            cb3.DataSource = new List<ComboBoxItem> { new ComboBoxItem() { Text = "select class", Value = 0 } };
        }
        else
        {
            cb3.DataSource = GetClassesForCourse((int)cb2.SelectedValue);
        }
    }
