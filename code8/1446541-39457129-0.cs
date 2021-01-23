            private void TextBox_TextChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (TextBox.Text.Length == 0)
            {
                return;
            }
            if (TextBox.Text.Contains("AWP"))
            {
                listBox2.DataSource = autoCompleteSkinsList;
                listBox2.Refresh();
            }            
        }
        public void listBox2_DoubleClick(object sender, EventArgs e)
        {
            TextBox.Text = listBox2.Items[listBox2.SelectedIndex].ToString();
        }
