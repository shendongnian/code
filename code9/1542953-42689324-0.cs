    private void button1_Click(object sender, EventArgs e)
            {
                if (listBox1.SelectedIndex > 0)
                {
                    int selectedIndex = listBox1.SelectedIndex;
                    object selectedItem = listBox1.SelectedItem;
                    listBox1.Items.Remove(selectedItem);
                    listBox1.Items.Insert(selectedIndex - 1, selectedItem);
                    listBox1.SetSelected(selectedIndex -1, true); // here we go
                }
            }
