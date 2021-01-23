       private void comboBox1_TextChanged(object sender, EventArgs e)
            {
                ComboBox c = ((ComboBox)sender);
                string[] items = c.Items.OfType<string>().ToArray();
                bool matched = items.Any(i => i == c.Text.Trim().ToLower());
            }
