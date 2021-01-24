            int position = time.SelectionStart;
            int backup = position;
            if (position == 0 || position == 1 || position== 2)
            {
                date1 = date1.AddHours(-1);
            }
            if (position == 3 || position == 4 || position == 5)
            {
                date1 = date1.AddMinutes(-1);
            }
            if (position == 7 || position == 6 || position == 8)
            {
                date1 = date1.AddHours(-12);
            }
            time.Text = date1.ToString("hh:mm tt");
            time.SelectionStart = backup;
