    private void button1_Click(object sender, EventArgs e)
            {
                if (listBox1.SelectedItems.Count==0)
                {
                    label1.Text = "YYY-PKT-100";
                }
                if (listBox2.SelectedItems.Count==0)
                {
                    label1.Text = "XXX-PKT-100";
                }
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    label1.Text = "XXX-YYY";
                }
                else
                {
                    label1.Text = listBox1.SelectedItem + textBox1.Text + listBox2.SelectedItem;
                }
            }
