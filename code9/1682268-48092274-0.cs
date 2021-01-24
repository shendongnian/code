    private void timer1_Tick(object sender, EventArgs e)
    {
       timer1.Start();
       this.Time.Text = System.DateTime.Now.ToString("hh:mm:ss tt");
       //here --- which you are calling on GetData_Click event by making  
       //separate method and call it here also
    }
