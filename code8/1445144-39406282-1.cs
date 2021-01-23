    private void btnW_Click(object sender, EventArgs e)
        {
             if (obj != null)
            {
                     (obj as TextBox).Text += btnW.Text;
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
