    private void button1_Click(object sender, EventArgs e)    
    {
        textBox3.Text = Format(textBox1.Text, textBox2.Text);
    }
    private string Format(string word, string spaces)
    {
        int amount;
        int.TryParse(spaces, out amount);
        var str = word.PadLeft(amount + word.Length);
        str = str.PadRight(amount + str.Length);
        return str;
    }
