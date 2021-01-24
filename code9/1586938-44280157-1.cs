    // On class scope to have access from MouseEnter
    ToolTip tt = new ToolTip();
    private void pictureBox3_Click(object sender, EventArgs e)
    {
        int durationMilliseconds = 30000;        
        tt.IsBalloon = true;
        tt.InitialDelay = 0;
        tt.Show("tooltip text", pictureBox3, durationMilliseconds);
    }
