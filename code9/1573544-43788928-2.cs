    String searchValueInSecondsString = "3600";
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        var separateHourAndMinutes = row.Cells[2].Value.ToString().Split(':');
         
        // safety first! ;)
        if (separateHourAndMinutes.Length != 2)
        {
            Console.WriteLine("Wrong time value from grid!");
        }
        else
        {
            // safety second! ;)
            if (int.TryParse(separateHourAndMinutes[0], out var hours) && int.TryParse(separateHourAndMinutes[1], out var minutes) && int.TryParse(searchValueInSecondsString, out var searchValue))
            {
                // if you want to make something red, if the search value and the time value are higher and equal, use >= instead of >
                if (new TimeSpan(hours, minutes, 0).TotalSeconds > searchValue)
                {
                    Console.WriteLine("I make it red!");
                }
            }
        }
    }
