    private void call_on_load()
    {
        var year = Convert.ToInt16(textBoxYear.Text);
        var dt = new DateTime(year, 1, 1);
        var days = new DateTime(year + 1, 1, 1).Subtract(dt).Days;
        var months = Enumerable.Range(0, days).Select(d => dt.AddDays(d)).GroupBy(x => x.Month);
        foreach (var month in months)
        {
            tabControl.TabPages[month.Key - 1].Controls.Clear();
        }
        var query =
            from month in months
            let firstDayOfWeek = (int)month.First().DayOfWeek
            from date in month.OrderBy(q => q)
            select new
            {
                Tab = tabControl.TabPages[month.Key - 1],
                Date = date,
                Position = firstDayOfWeek + date.Day - 1,
            };
        foreach (var item in query)
        {
            var button = new Button()
            {
                Size = new Size(50, 50),
                Left = (item.Position % 7) * 75 + 10,
                Top = (item.Position / 7) * 75 + 20,
                Text = item.Date.ToShortDateString(),
            };
            button.Click += (s, e) =>
            {
                var secondForm = new Form2();
                secondForm.setDate(item.Date);
                secondForm.Show();
            };
            item.Tab.Controls.Add(button);
        }
    }
