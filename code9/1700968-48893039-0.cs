    private void button1_Click(object sender, EventArgs e)
    {
     if(FormB.OnTop)
     {
      FormA.Focus();
     }
     else
     {
      FormB.OnTop = true;
      FormB.Focus();
     }
    }
