    public Form1()
    {
        // Snip
        trackBar1.ValueChanged += trackbar1_ValueChanged;
    }
    private void trackbar1_ValueChanged(object sender, EventArgs e)
    {
        textBox1.Text = trackBar1.Value.ToString();
    }
        
