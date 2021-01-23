    private void new_form_Click(object sender, EventArgs e)
    {
        add = new Add(this); \\this part was missing
        add.TopLevel = false;
        add.Visible = true;
        add.FormBorderStyle = FormBorderStyle.None;
        add.Dock = DockStyle.Fill;
        var tabIndex = tabControl1.TabCount;
        tabControl1.TabPages.Insert(tabIndex, "New Tab");
        tabControl1.SelectedIndex = tabIndex - 1;
        tabControl1.TabPages[tabIndex - 1].Controls.Add(add);
    }
    public string setTabTitle
    {
        set { tabControl1.TabPages[tabControl1.SelectedIndex].Text = value; }
    }
