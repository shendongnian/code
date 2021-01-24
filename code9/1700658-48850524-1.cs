    Timer labelTimer = new Timer() {Interval = 5000};
    private void Form1_Load(object sender, EventArgs e)
    {
        label1.TextChanged += label1_TextChanged;
        labelTimer.Tick += labelTimer_Tick;
    }
    private void label1_TextChanged(object sender, EventArgs e)
    {
        //Restart timer.
        labelTimer.Stop();
        labelTimer.Start();
    }
    private void labelTimer_Tick(object sender, EventArgs e)
    {
        if(label1.Text == "silence") {
            //label1 has had the text "silence" for 5 seconds. Do something.
            labelTimer.Stop(); //Wait until the next text change.
        }
    }
