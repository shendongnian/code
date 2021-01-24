    private void fourBtn_Click(object sender, EventArgs e) {
     string theName = "Level4";
     TabPage tp = new TabPage(theName);
     if (!tabControl1.TabPages.Contains(tabPage2)) {
    
      tp.Name = theName;
      tabControl1.TabPages.Add(tp);
    
      TextBox tb = new TextBox();
      tb.Dock = DockStyle.Fill;
      tb.Multiline = true;
      tp.Controls.Add(tb);
     }
    }
    
