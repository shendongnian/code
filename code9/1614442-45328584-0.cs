    private void Form1_Load(object sender, EventArgs e)
    {
        click.Enabled = false;      //click is timer which i added to forms!
        click.Interval = 1000;    
        click.Elapsed += new ElapsedEventHandler(click_Tick);
    }
    private void Loop_MouseDown(object sender, MouseEventArgs e)
    {
    while (e.Button == MouseButtons.Left)
        {
            click.Enabled = true;
        }
    }
    private void click_Tick(object sender, ElapsedEventArgs e)
    {
          //Here is the loop!
    }
