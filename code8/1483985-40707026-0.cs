    public void buttonenableordisable()
    {
        button1.Enabled = !String.IsNullOrEmpty(textBox1.Text);
    }
    
    private void currencyTextBox_TextChanged(object sender, EventArgs e)
    {
        buttonenableordisable();
    }
