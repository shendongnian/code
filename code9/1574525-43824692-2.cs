    private void Form1_Load(object sender, EventArgs e)
    {
        var item = new ToolStripControlHost(new DateTimePicker());
        ((DateTimePicker)item.Control).ValueChanged += ToolStripDatePicker1_ValueChanged;
        item.Name = "ToolStripDatePicker1";
        toolStrip1.Items.Add(item);
    }
    private void ToolStripDatePicker1_ValueChanged(object sender, EventArgs e)
    {
        var datePicker = (DateTimePicker)sender;
        MessageBox.Show(datePicker.Value.ToString());
    }
