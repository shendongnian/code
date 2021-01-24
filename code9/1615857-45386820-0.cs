    Boolean found = false;
            if (!string.IsNullOrWhiteSpace(this.textBox1.Text))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string conbarcode = this.textBox1.Text;
                    conbarcode = this.textBox1.TextLength == 10 ? this.textBox1.Text : Convert.ToDouble(this.textBox1.Text).ToString("0000000000").ToString();
                    foreach (DataGridViewRow row in this.dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value.Equals(conbarcode))
                        {
                            // row exists
                            found = true;
                            row.Cells["qty"].Value = Convert.ToInt32(row.Cells["qty"].Value) + 1;
                            row.Cells["qty"].Selected = true;
                            //MessageBox.Show("Row already exists");
                            break;
                        }
                    }
                    if (found)
                    {
                        this.textBox1.BackColor = Color.LightGreen;
                        return;
                    }
