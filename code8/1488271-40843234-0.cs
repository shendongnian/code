    public void SecondButton_Click(object sender, EventArgs)
    {
        int n = Convert.ToInt32(text_flats_blocks.Text);
        for (int i = 0; i < n; i++)
        {
            var control= (TextBox)FindControl("text_" + (i+1));
            //now you have the controls and you can do whatever you want with them 
        }
    }
