    private void Form1_Load(object sender, EventArgs e)
    {
        foreach (var comboBox in this.Controls.OfType<ComboBox>())
        {
            comboBox.TextChanged += Item_TextChanged;
            InitializeComboBox(comboBox);
        }
    }
    
    private void Item_TextChanged(object sender, EventArgs e)
    {
        double result = 0;
        foreach (var comboBox in this.Controls.OfType<ComboBox>())
        {
            if (!string.IsNullOrEmpty(comboBox.Text))
            {
                result += Convert.ToDouble(comboBox.Text);
            }
        }
    
        textBox1.Text = result.ToString();
    }
    
    private void InitializeComboBox(ComboBox comboBox)
    {
        for (int index = 0; index < 10; index++)
        {
            comboBox.Items.Add(index + 0.5);
        }
    }
