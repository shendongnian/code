            int total = 0;
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                total = total+ int.Parse(listBox2.Items[i].ToString());
            }
            textBox1.Text = total.ToString();
