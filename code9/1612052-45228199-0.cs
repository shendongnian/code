    private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            string curItem1 = listBox1.SelectedItem.ToString();
            if (curItem1 == "1")
            {
                listBox2.Items.Add(1);
                listBox2.SelectedIndex = 0;  //<= This selects the item
                if (curItem1 == "1")
                {
                    listBox3.Items.Add(1);
                }
                string curItem2 = listBox2.SelectedItem.ToString();
                ///This is where I get the error!
            }
        }
