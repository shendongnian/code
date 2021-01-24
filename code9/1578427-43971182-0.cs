    private void clickHandler(object sender, EventArgs e)
    {
        PictureBox pic = (PictureBox)sender;      // get the control that was clicked on
        string name = (string)pic.Tag;            // retrieve the name from the Tag property
        MessageBox.Show("You clicked " + name);
    }
