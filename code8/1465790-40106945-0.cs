    string message = string.Empty; //Never change.
    
    public void OnMessageReceieve(string message)
    {
       //  I have a message in message variable (this is a parameter, not a field class)
       txtMessage.Text += message;
       Timer1.Enabled = true;
       Timer1_Tick(null, null);
       // UpdatePanel1.Update();                  
    }
    
    protected void Timer1_Tick(object sender, EventArgs e)
    {
       //message variable gets empty here?
       if (!string.IsNullOrEmpty(message)) //<-- this.message
       {
          txtMessage.Text += message;
       }                
    }
