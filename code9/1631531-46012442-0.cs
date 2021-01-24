    protected void Button1_Click(object sender, EventArgs e)
    {
       DateTime txtMyDate = DateTime.Parse(TextBox2.Text);
       if (DateTime.Now.Date == txtMyDate)
       {
           Label2.Text = "Happy Birthday";
       }
       else
       {
           Label2.Text == "Have a nice day";
    
       }
    }
