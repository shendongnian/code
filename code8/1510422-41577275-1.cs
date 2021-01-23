    private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Might work
        if (this.IsDisposed)
            return;
        // Or this
        if (comboBox == null)
            return;
        if (comboBox.SelectedValue == null)
        {
            MessageBox.Show("NULL");
        }
        else
        {
            label2.Text = comboBox.SelectedValue.ToString();
        }
    }
