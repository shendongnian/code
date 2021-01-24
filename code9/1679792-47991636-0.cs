    private void timer2_Tick(object sender, EventArgs e)
    {
        var hours = Convert.ToInt16(Properties.Settings.Default.shift_1_end_hh);
        var minutes = Convert.ToInt16(Properties.Settings.Default.shift_1_end_min);
        var date1 = DateTime.Today.AddHours(hours).AddMinutes(minutes);
        int result = DateTime.Compare(date1,DateTime.Now);
        if (result == 0)
        { 
             timer2.Enabled = false;
             MessageBox.Show("tttt"); 
        }
    }
