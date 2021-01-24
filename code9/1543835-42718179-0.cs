     In Form1{
    Form2 = new Formtoopen();
    Form3 = new Formdata();
    Form2.FormClosing +=new FormClosingEventHandler(Form_FormClosing);
    Form3.FormClosing += new FormClosingEventHandler(Form_FormClosing);
    }
     In Form1{
    protected virtual void Form_Closing(object sender, FormClosingEventArgs  e)
    {
    if (e.CloseReason == CloseReason.UserClosing)
    {
      e.Cancel = true;
      ((Form)sender).Hide();
    }
    }
