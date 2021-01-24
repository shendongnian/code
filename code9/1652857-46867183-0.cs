    private void Button_Click(object sender, EventArgs e)
    { 
        Button button = (Button)sender;
        var data = button.Tag as int[];
        string s = data[1].ToString();
        MessageBox.Show(s);
    }
