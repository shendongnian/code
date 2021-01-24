    foreach (Control rb in this.Controls.OfType<RadioButton>())
    {
        RadioButton rbs = sender as RadioButton();
        if(rbs.Checked == true)
        {
            MessageBox.Show("Hi");
            return;
        }
    }
