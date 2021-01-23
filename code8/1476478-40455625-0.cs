    var countries = new List<string>();
    private void accept_Click(object sender, EventArgs e)
    {
        countries.Add(textBox1.Text);
    }
    private void finish_Click(object sender, EventArgs e)
    {
        foreach (string coun in countries)
            MessageBox.Show("You have entered " + coun);
    }
