       private void Button1_Click(object sender, EventArgs e)
        {
            TabPage tabPage1 = (TabPage) sender;
 
            Form frm = new Form();
            frm.Text = tabPage1.Text;
            Panel panel = (Panel) tabPage1.Controls[0];
            tabPage1.Controls.RemoveAt(0);
            tabControl.TabPages.Remove(tabPage1);
  
            frm.Controls.Add(panel);
            frm.Show();
        
        }
        private void Form1_Click(object sender, EventArgs e)
        {
            Form frm = (Form) sender;
            TabPage tabPage1 = new TabPage();
            tabPage1.Text = frm.Text;
            Panel panel = (Panel)frm.Controls[0];
            frm.Controls.RemoveAt(0);
            tabControl.TabPages.Add(tabPage1);
            frm.Controls.RemoveAt(0);
            frm.Hide();
        }
