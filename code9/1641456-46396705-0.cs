     private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstInputs == null)
                lstInputs = new List<string>();
            if (e.KeyCode == Keys.Enter)
            {
                lstInputs.Add(textBox2.Text);
                textBox2.Text = string.Empty;
                MessageBox.Show("Message has been saved.");
            }
        }
