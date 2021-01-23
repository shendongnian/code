    private void button4_Click(object sender, EventArgs e)
    {
        List<CheckBox> Checkboxlist = new List<CheckBox>();
        foreach (CheckBox control in this.Controls.OfType<CheckBox>())
        {
            Checkboxlist.Add(control);
            control.Checked = false;
        }
        Random r = new Random();
        int g = 0;
        for ( int i = 0; i < Checkboxlist.Length; i++){
            g = r.Next(0,1);
            if(g ==1)
                Checkboxlist[i].Checked = true;
        }
    }
