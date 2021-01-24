        DateTime newDateTime;
        if (DateTime.TryParse(textBox1.Text, out newDateTime))
        {
            dateTimePicker1.Value = newDateTime;
        }
        else
        {
            // Datetime is invalid
        }
