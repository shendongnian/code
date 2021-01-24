    private void RunEvent(object sender, System.EventArgs e)
    {
        selectingtime(); //This?
        label1.Text = DateTime.Now.ToLongTimeString(); 
        DateTime dateT = DateTime.Now; // created datetime
       if (dateT.ToString("hh:mm tt") == selectedtime) // condition where dateT.ToString is equal to selectedtime 
       {
           MessageBox.Show("Please work"); // expected output whenever dateT.ToString is equal to selected time.
       }
    }
