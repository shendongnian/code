    private void toolStripButton1_Click(object sender, EventArgs e)
    {
        var item = ((ToolStripControlHost)this.toolStrip1.Items["ToolStripDatePicker1"]);
        var datePicker = (DateTimePicker)item.Control;
        MessageBox.Show(datePicker.Value.ToString());
    }
