    private void tagToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (dataGridView1.EditingControl is TextBox)
        {
            var textBox = (TextBox)dataGridView1.EditingControl;
            MessageBox.Show(textBox.SelectedText);
        }
    }
