    // some way to access other form...
    public Form OtherForm { get; set; }
    private void button1_Click(object sender, EventArgs e)
    {
        OtherForm.FullScreenMode();
    }
