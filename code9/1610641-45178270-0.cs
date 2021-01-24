    private void UpdateMonthCombo()
        {
            List<Tuple<int, string>> AL = new List<Tuple<int, string>>();
            string[] monthNames = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            for (int i = 0; i < 12; i++)
            {
                AL.Add(new Tuple<int, string>(i + 1, monthNames[i]));
            }
            comboMonth.DataSource = AL;
            comboMonth.ValueMember = "Item1";
            comboMonth.DisplayMember = "Item2";
            comboMonth.SelectedItem = null;
        }
