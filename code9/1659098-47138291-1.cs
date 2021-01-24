    private void button3_Click(object sender, EventArgs e)
    {
         string s = "    Search Via Forename";
         int result = 0;
         int count = 0;
         result = string.Compare(textBox1.Text, s);
           
         if ((result == 0) || (String.IsNullOrEmpty(textBox1.Text)))
         {
             MessageBox.Show("Please input forename...");
             return;
         }
 
         foreach(ListViewItem item in listView1.Items)
         {
             if (item.Text.ToLower().StartsWith(textBox1.Text.ToLower()))
             {
                 count++;                        
                 statusBar1.Panels[2].Text = "Found: " + count.ToString();
             }
             else
             {
                 listView1.Items.Remove(item); 
             }
         }
         button1.Text = "Clear";
         textBox1.Visible = button3.Visible = button2.Visible = false;
    }
