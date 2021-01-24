    public class Tax
    {
        public decimal Value { get; }
        public string Text { get => Value.ToString("0.## '%'"); }
        public Tax(decimal value)
        {
            Value = value;
        }
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        var taxes = new[]
        {
            new Tax(15),
            new Tax(18),
            new Tax(20),
        }
        comboBox1.ValueMember = "Value";
        comboBox1.DisplayMember = "Text";
        comboBox1.DataSource = taxes;
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox1.SelectedValue = 15;
    }
