    private void btnW_Click(object sender, EventArgs e)
        {
            if (obj != null)
            {
                if (obj == txtCategory)
                {
                    txtCategory.Text += btnW.Text;
                }
                else
                {
                    textBox1.Text += btnW.Text;
                }
            }
        }
        object obj;
        private void txtCategory_Click(object sender, EventArgs e)
        {
            obj = txtCategory;
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            obj = textBox1;
        }
