    if (listBox1.SelectedIndex != null)
            {
                try { var Information = ((ItemObject)listBox1.SelectedItem).ItemInfo;
                    richTextBox2.Text = Information;
                }
                catch( Exception ex)
                {
                }
            }
