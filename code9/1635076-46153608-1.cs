    private void timer1_Tick(object sender, EventArgs e)
    {
        x += 1;
        label1.Text = x.ToString();
        if (x % 10 == 0)
        {
             Thread t = new Thread(addpoint); 
             t.Start();
        }
    }
