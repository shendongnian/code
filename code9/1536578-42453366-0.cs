     private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(); //We will put all your entered strings here.
            for (int x=0; x< comboBox1.Items.Count; x++)
            {
                sb.Append(comboBox1.GetItemText(comboBox1.Items[x]) + Environment.NewLine); //I added new line for better reading since you have scrollbar
            }
            textBox1.Text = sb.ToString(); //Display the result on your textbox
        }
