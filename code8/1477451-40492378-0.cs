    private void button1_Click(object sender, EventArgs e)
    {  
        if (App.Form1 != null)
          {
            App.Form1 = new Form1();
          }
        App.Form1.Show();
        App.Form2.Hide();
    }
