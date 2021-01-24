    public void add_chkbx()
    {
        // for each picture box add check box
        foreach (Control cont in this.Controls)
        {
            if (!(cont is PictureBox))
                continue;
            CheckBox chk = new CheckBox();
            chk.Size = new System.Drawing.Size(30, 30);
            chk.BackColor = Color.Transparent; // transparent color for checkbox
            cont.Controls.Add(chk);
        }
    }
    
    private void Button1Click(object sender, EventArgs e)
    {
        add_chkbx();
    }
