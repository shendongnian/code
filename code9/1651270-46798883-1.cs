    private void button1_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(txtUserInput.Text))
        {
            button1.Text = txtUserInput.Text;
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("You chose: " + openFileDialog.FileName);
            }
        }
    }
