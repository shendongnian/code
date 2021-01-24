    private void Button_Click(object sender, EventArgs e)
    { 
        string s;
        Button button = (Button)sender;
        s = button.Text + Environment.NewLine;
        MessageBox.Show(button.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None)[1]);
    }
