    private void button1_Click(object sender, EventArgs e)
    {        
        Properties.Settings.Default["SomeProperty"] = tarahi_algouritm.Checked;
        Properties.Settings.Default.Save();
    }
