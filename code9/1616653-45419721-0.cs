            DateTime newDateTime;
            if (DateTime.TryParse(textBox1.Text, out newDateTime))
            {
                dateTimePicker1.Value = DateTime.Parse(textBox1.Text);
            }
            else
            {
                // Datetime is invalid
            }
