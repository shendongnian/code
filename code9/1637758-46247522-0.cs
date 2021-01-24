    public List<string> Values = new List<string>();
    public void UpdateValues()
    {
        var value = textBox1.Text;
        Values.Add(value);
        textBox1.Clear();
        
    }
    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char) Keys.Return)
        {
            UpdateValues();
        }
    }
