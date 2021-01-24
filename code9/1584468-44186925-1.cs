    private void boyButton_Click(object sender, EventArgs e)
    {
        string boyname = boyTextBox.Text;
        bool found = false;
        for(int n = 0; n < boyNameListbox.Items.Count; n++)
        {
            if (boyNameListbox.Items[n] == boyname)
            {
                found = true;
                break;
            }
        }
        if (found)
            MessageBox.Show("popular");
        else
            MessageBox.Show("not popular");
    }
