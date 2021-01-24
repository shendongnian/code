    ComboBox1.SelectedValue = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
    comboBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
    String s = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
    //culture is set to british based on your date format
    DateTimeFormatInfo culture = (new CultureInfo("en-GB")).DateTimeFormat;
    DateTime dt; //declare variable to hold our datetime
    //since this is DB data, use "tryparse" as it may not be formatted properly
    if (DateTime.TryParse(s, culture, DateTimeStyles.None,out dt))
        dateTimePicker1.Value = dt;
