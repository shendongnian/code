        private void button2_Click(object sender, EventArgs e)
        {
            if (!(listBox1.SelectedIndex == -1))
            {
                int index = listBox1.SelectedIndex;
                listBox1.Items.Remove(listBox1.SelectedItem);
                if (index > 0)
                    listBox1.SetSelected(index - 1,true);
                else if(listBox1.Items.Count > 0)
                    listBox1.SetSelected(0, true);
            }
            else
                MessageBox.Show("You have not selected an item");
        }
