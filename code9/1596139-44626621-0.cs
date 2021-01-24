    public int PassValue { get; set; }
    private void button1_Click(object sender, EventArgs e)
    {
        int tmp;
        Int32.TryParse(textBox2.Text, out tmp);
        this.PassValue = tmp;
        this.DialogResult = DialogResult.OK;
    }
