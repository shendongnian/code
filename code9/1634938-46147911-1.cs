    private void textBox2_TextChanged(object sender, EventArgs e)
            {
                int n;
                bool isNumeric = int.TryParse(textBox2.Text, out n);
                if (!isNumeric) return;
                string HexKey = textBox2.Text;
                int key = Convert.ToInt32(HexKey, 16);
            }
