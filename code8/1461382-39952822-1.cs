    private void call_on_load()
    {
        var year = Convert.ToInt16(textBoxYear.Text);
        var dt = new DateTime(year, 1, 1);
        var months =
            Enumerable
                .Range(0, dt.AddYears(1).Subtract(dt).Days)
                .Select(d => dt.AddDays(d))
                .GroupBy(x => x.Month);
        foreach (var month in months)
        {
            var tab = tabControl.TabPages[month.Key - 1];
            tab.Controls.Clear();
            var firstDayOfWeek = (int)month.First().DayOfWeek;
            foreach (var date in month)
            {
                var position = firstDayOfWeek + date.Day - 1;
                var button = new Button()
                {
                    Size = new Size(50, 50),
                    Left = (position % 7) * 75 + 10,
                    Top = (position / 7) * 75 + 20,
                    Text = date.ToShortDateString(),
                };
                button.Click += (s, e) =>
                {
                    var secondForm = new Form2();
                    secondForm.setDate(date);
                    secondForm.Show();
                };
                tab.Controls.Add(button);
            }
        }
    }
