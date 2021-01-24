        protected void cal1_SelectionChanged1(object sender, EventArgs e)
        {
            caldate1.Text = cal1.SelectedDate.ToShortDateString();
            IsValidDate();
        }
        protected void cal2_SelectionChanged(object sender, EventArgs e)
        {
            caldate2.Text = cal2.SelectedDate.ToShortDateString();
            IsValidDate();
        }
        private void IsValidDate()
        {
            response.Text = string.Empty;
            if (cal1.SelectedDate > cal2.SelectedDate)
            {
                response.Text = "Date should be later than first date";
            }
        }
