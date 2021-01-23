      private void listBox1_Click(object sender, EventArgs e)
        {
            string str = ((ListBox)(sender)).Text;
            Process.Start(str);
        }
