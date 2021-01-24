    // Keep track of currently selected index
    private int lastSelectedIndex = 0;
    private void Form1_Load(object sender, EventArgs e)
    {
        comboBox1.DataSource = Enum.GetValues(typeof(Articlestatus));
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        // Select first item and update our tracking variable
        comboBox1.SelectedIndex = 0;
        lastSelectedIndex = comboBox1.SelectedIndex;
    }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // If the newly selected item is less than the previous one, reset to previous one
        if (comboBox1.SelectedIndex < lastSelectedIndex)
        {
            comboBox1.SelectedIndex = lastSelectedIndex;
        }
        else
        {
            lastSelectedIndex = comboBox1.SelectedIndex;
        }
    }
