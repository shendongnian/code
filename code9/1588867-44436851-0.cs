        DateTime start = new DateTime();
        start = dateTimePicker1.Value;
        DateTime end = new DateTime();
        end = dateTimePicker2.Value;
        var dates = new List<DateTime>();
        richTextBox1.Text = "";
        for (var dt = start; dt <= end; dt = dt.AddDays(1))
        {
            dates.Add(dt);
            richTextBox1.Text += dt.ToString();
        }
