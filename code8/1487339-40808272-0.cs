    private void ComboBox1_SelectedIndexChanged(object sender,System.EventArgs e)
    {
     try
     {
       if(ComboBox1.Text == "present")
        {
          label.Text = DateTime.Now.ToString(@"MM\/dd\/yyyy HH:mm");
        } 
     }catch(Exception)
     {
     }
    }
