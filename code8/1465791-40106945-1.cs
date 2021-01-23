    string message = string.Empty;
    public void OnMessageReceieve(string message)
    {
       //  I have a message in message variable
       this.message = message; //<-- Add this line.
       txtMessage.Text += message;
       Timer1.Enabled = true;
       Timer1_Tick(null, null);
       // UpdatePanel1.Update();                  
    }
    
    protected void Timer1_Tick(object sender, EventArgs e)
    {
       //message variable gets empty here?
       if (!string.IsNullOrEmpty(message))
       {
          txtMessage.Text += message;
       }                
    }
