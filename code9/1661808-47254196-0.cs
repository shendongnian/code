    private void timer1_Tick(object sender, EventArgs e)
    {
        using (var client = new HttpClient())
        { 
            string data = client.GetStringAsync("http://fms.psrpc.co.uk/apistate.php?" + ApiKey).GetAwaiter().GetResult();
            if (data == "State 1")
            {
                label4.Text = "On Duty";
                label4.ForeColor = Color.Gray;
            }
            else
            if (data  == "State 2")
            {
                label4.Text = "Available for calls";
                label4.ForeColor = Color.Green;
            }
            else
            if (data == "State 4")
            {
                label4.Text = "On Break";
                label4.ForeColor = Color.Yellow;
            }
            else
            if (data == "State 5")
            {
                label4.Text = "Responding to call";
                label4.ForeColor = Color.Orange;
            }
            else
            if (data == "State 6")
            {
                label4.Text = "On Scene";
                label4.ForeColor = Color.LightBlue;
            }
            else
            if (data == "State 7")
            {
                label4.Text = "Traffic Stop";
                label4.ForeColor = Color.Purple;
            }
            else
            if (data == "PANIC")
            {
                label4.Text = "PANIC BUTTON ACTIVATED";
                label4.ForeColor = Color.Red;
            }
            else
            if (data == "Assigned")
            {
                label4.Text = "Assigned to call";
                label4.ForeColor = Color.Brown;
            }
        }
    }
