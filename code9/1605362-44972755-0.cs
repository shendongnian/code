    private void Btn_Validate_Click(object sender, EventArgs e)
        {
            tb_TotalTime.Text = calculateTotalTime().ToString();
        }
        public int calculateTotalTime()
        {
            int total = 0;
            foreach (Activity a in activities)
            {
                if (a.isChecked())
                {
                    total += a.getTimeSpent();
                }
            }
            return total;
        }
