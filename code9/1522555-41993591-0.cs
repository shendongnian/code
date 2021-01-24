        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            int total1 = int.Parse(txtTotal.Text);
            if (listBox1.SelectedValue.ToString() == "item1 600")
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                total1 -= 600;
                txtTotal.Text = total1 + "";
            }
        }
