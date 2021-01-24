     private void button1_Click(object sender, EventArgs e)
        {
            string[] strArray = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                strArray[i] = listBox1.Items[i].ToString();
            }
            label1.Text = "Coppied items";
        }
