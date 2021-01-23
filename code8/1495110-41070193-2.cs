    //Menu Form
    private void button_Click(object sender, EventArgs e)
    { 
    this.Hide();
    using(PopUp form3 = new Popup()) 
        form3.ShowDialog();
    this.Show();
    } 
    //PopUp Form
    private void button_Click(object sender, EventArgs e)
     {
      this.Hide();
      using(Task form4 = new Task())
          form4.ShowDialog();
      this.Close();      
     }
    //Task Form
    private void button_Click(object sender, EventArgs e)
    {
      this.Close();
    }
