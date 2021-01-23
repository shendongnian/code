    private void button4_Click(object sender, EventArgs e)
    {
        List<CheckBox> Checkboxlist = new List<CheckBox>();
        foreach (CheckBox control in this.Controls.OfType<CheckBox>())
        {
            Checkboxlist.Add(control);
            control.Checked = false;
        }
    
        var random = new Random();
        for (int i = 0; i <= 200; i++)
        {
            var r = random.Next(0, Checkboxlist.Count);
            var checkbox = Checkboxlist[r];
                checkbox.Checked = true;
        }
    }
