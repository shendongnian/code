    decimal x=0;
    decimal y =0;
    private void NumericUpDownVx_ValueChanged(object sender, EventArgs e)
    {
         x = NumericUpDownVx.Value;
    }
    private void NumericUpDownVy_ValueChanged(object sender, EventArgs e)
    {
          y = NumericUpDownVy.Value;
    }
    private void ButtonStart_Click(object sender, EventArgs e)
    {
        if (buttonStart.Text == "Start")
        {
            numericUpDownVx.Enabled = false;
            numericUpDownVy.Enabled = false;
            buttonStart.Text = "Stop";
            Timer1.Start();
        } 
        else if (buttonStart.Text == "Stop")
        {
            numericUpDownVx.Enabled = true;
            numericUpDownVy.Enabled = true;
            buttonStart.Text = "Start";
            Timer1.Stop();
            Timer2.Stop();
            Timer3.Stop();
            Timer4.Stop();
        }
    }
    private void Timer1_Tick(object sender, EventArgs e)
    {
        ball.Top = x + 5;
        ball.Left = y + 5;
        if (ball.Left + ball.Width > Mesa.Width)
        {
            Timer1.Stop();
            Timer2.Start();
        }
        if (ball.Top + ball.Height > Mesa.Height)
        {
            Timer1.Stop();
            Timer3.Start();   
        }
    }
