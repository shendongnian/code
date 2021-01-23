    public void OnMessageReceieve(string message)
    {
         txtMessage.Text += message;
     
         // set member!!
         this.message = message;
         Timer1.Enabled = true;
         Timer1_Tick(null, null);
         // UpdatePanel1.Update();          
    }
