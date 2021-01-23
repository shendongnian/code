           private void presd_btn(object sender, EventArgs e)
           {
            Button mybutn = sender as Button;
            int btnum=mybutn.Tag;
            listBox1.Items.Insert(0, " ");
           if ((checkBox_pickup.CheckState != 0) && (checkBox_family.CheckState != 0))
           {
            listBox1.Items.Insert(1, listBox1.Items.Count);
            listBox1.Items.Insert(2, "PICKUP");
            listBox1.Items.Insert(3, textBox2.Text);
            listBox1.Items.Insert(4, textBox1.Text);
            listBox1.Items.Insert(5, "Family");
              //and here you assign the pressed button's text
            listBox1.Items.Insert(5, mybtn.Text);
            listBox1.Items.Insert(6, DateTime.Now.ToString());
            listBox1.Items.Insert(listBox1.Items.Count, textBox4.Text);
           //......
           }
