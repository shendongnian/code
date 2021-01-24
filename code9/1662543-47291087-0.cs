    public void StartBlink()
    {
        BlinkMe.BlinkedLabel = this.label1;
        // start blinking
        System.Threading.Thread t1 = new System.Threading.Thread(BlinkMe.Blink);
        t1.Start();
    }
    private void btnStopBlinking_Click(object sender, EventArgs e)
    {
        // stop blinking
        BlinkMe.IsBlinking = false;
    }
