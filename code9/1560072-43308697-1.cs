        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.NewTextChanged += Frm2_NewTextChanged;
            frm2.Show();
        }
        private void Frm2_NewTextChanged(string item)
        {
            lbItem.Items.Add(item);
        }
