     int x, y, z;
            StringBuilder sb = new StringBuilder();
            y = int.Parse(textBox1.Text);
            z = int.Parse(textBox2.Text);
            label4.Text = " ";
            for (x = 1; x <= y; x++)
            {
                sb.Append( label4.Text + comboBox1.Text);
            }
            sb.Append("\n");
            for (x = 1; x <= z; x++)
            {
                sb.Append(label4.Text + comboBox1.Text + "\n");
            }
            label4.Text = sb.ToString();
