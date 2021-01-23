     private void Form1_Load(object sender, EventArgs e)
        {
            for (int Count = 11; Count <= 16; Count++)
            {
                ((NumericUpDown)(Controls["NW" + Count])).Value = (decimal)Properties.Settings.Default["_NW" + Count];
            }
        }
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            for (int Count = 11; Count <= 16; Count++)
            {
                Properties.Settings.Default["_NW" + Count] = ((NumericUpDown)(Controls["NW" + Count])).Value;
            }
            Properties.Settings.Default.Save();
        }
