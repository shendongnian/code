    private void timer1_Tick(object sender, EventArgs e)
    {
        if (InvokeRequired) { Invoke(new Action(() => { timer1_Tick(sender, e); })); return; }
        time++;
        if (time==3)
        {
            this.Close();
        }
    }
