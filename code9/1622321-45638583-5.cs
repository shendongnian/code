    private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        // here you can specify whether the toggeling should occur or not
        if (Checkbox_toggle.Checked)
        {
            // toggling needs to be invoked since it is called on a different thread
            this.checkBox_Control.BeginInvoke(
                    new Action(() => this.checkBox_Control.Checked = !this.checkBox_Control.Checked));
        }
    }
