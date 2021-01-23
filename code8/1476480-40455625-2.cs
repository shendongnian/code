    var countries = new List<string>();
    private void accept_Click(object sender, EventArgs e)
    {
        var input = textBox1.Text.Split(',');
        countries.AddRange(input);
    }
    private void finish_Click(object sender, EventArgs e)
    {
        foreach (string coun in countries)
            MessageBox.Show("You have entered " + coun);
    }
