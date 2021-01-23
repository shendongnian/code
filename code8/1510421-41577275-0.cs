    private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.IsDisposed)
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
