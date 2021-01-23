    private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            for (int Count = 11; Count <= 16; Count++)
            {
                Properties.Settings.Default.("_NW" + Count) = this.Controls.("NW" + Count).Value;
                Properties.Settings.Default.Save();
            }
        }
