    int indexOfTabPage = 5;
    List<string> myData = new List<string>();
    foreach(Control c in this.tabControl1.TabPages[indexOfTabPage].Controls)
    {
       if(c is TextBox && !string.IsNullOrEmpty(c.Text) && c.Tag != null && c.Tag.ToString() == "500")
       {
          myData.Add(c.Text);
       }
    }
