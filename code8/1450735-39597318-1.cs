    public void Form1_Load(object sender, EventArgs e)
    {
        tm2.Interval = 1000;
        tm2.Tick += timer2_Tick;
    }
    private void buttonTwo_Click(object sender, EventArgs e)
    {
        DoClickWork();
    }
    System.Windows.Forms.Timer tm2 = new System.Windows.Forms.Timer();
    private void DoClickWork()
    {
        buttonTwo.Text = "Reactivating in 5 seconds";
        buttonTwo.Enabled = false;
        tm2.Enabled = true;
        sayingTwo.Visible = false;
    }
    int ii = 4;
    private void timer2_Tick(object sender, EventArgs e)
    {
        if (ii != 0)
        {
            ii -= 1;
            buttonTwo.Text = "Reactivating in " + ii + " seconds";
        }
        if (ii == 0)
        {
            ii += 4;
            tm2.Enabled = false;
            buttonTwo.Enabled = true;
            buttonTwo.Text = "Click To Hide Saying";
            sayingTwo.Visible = true;
        }
    }
}
