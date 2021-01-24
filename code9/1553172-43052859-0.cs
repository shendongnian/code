     private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage1);
            if (tabControl1.TabPages.Count <= 1)
            {
                tabControl1.TabPages.Insert(0, tabPage1);
                this.tabPage1.Show();
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage4);
                this.tabPage2.Hide();
                this.tabPage3.Hide();
                this.tabPage4.Hide();
            }
        }
