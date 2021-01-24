    this.VlcControl.Play();
    this.Show();
    
    int counter = 0;
    while (counter < 20)
    {
    	Debug.WriteLine(this.VlcControl.State);
    	counter += 1;
    	Application.DoEvents();
    	Thread.Sleep(100);
    	this.VlcControl.Video.Adjustments.Enabled = true;
    	this.VlcControl.Video.Adjustments.Saturation = 1.35f;
    }
