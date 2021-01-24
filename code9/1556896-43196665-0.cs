    private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
    {
        // Update the text in TextBox4 first...
        textBox4.Text = monthCalendar2.SelectionStart.ToShortDateString();
        var startDate = DateTime.Parse(textBox3.Text);
        var endDate = DateTime.Parse(textBox4.Text);
        // Rest of the code omitted...
