     if (e.KeyCode == Keys.Enter)
            {
                int a, b, c;
                a = int.Parse(label1.Text);
                b = int.Parse(label2.Text);
                c = a - b;
                label3.Text = c.ToString();
                return;
            }
            if (!(Char.IsDigit((char)e.KeyData) || (e.KeyData == Keys.Up)))
            {
                MessageBox.Show("please enter digits only");
            }
