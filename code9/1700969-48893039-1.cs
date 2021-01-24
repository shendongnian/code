    private void button1_Click(object sender, EventArgs e)
    {
     if(FormB.OnTop)
     {
      FormB.OnTop = false;
      this.Focus();
     }
     else
     {
      FormB.OnTop = true;
      FormB.Focus();
     }
    }
