    public Delegate ChangeText;
    private void button1_Click(object sender, EventArgs e)
    {
        int tmp;
        Int32.TryParse(textBox2.Text, out tmp);
        ChangeText.DynamicInvoke(tmp.ToString()); // important line
    }
