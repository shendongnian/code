    trackBar1.MouseWheel += new MouseEventHandler(Disable_MouseWheel);
   
    private void Disable_MouseWheel(object sender, EventArgs e)
    {
        HandledMouseEventArgs ee = (HandledMouseEventArgs)e;
        ee.Handled = true;
    }
