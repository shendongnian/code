    private void button1_Click(object sender, EventArgs e)
    {
       if (this.InvokeRequired)
       {
          this.Invoke(new EventArgsDelegate(button1_Click), new object[] { sender, ea });
       }
       // Do some stuff
    }
