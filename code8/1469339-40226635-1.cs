    private static Random random = new Random(); // Class member
    private void button4_Click(object sender, EventArgs e)
    {
        List<CheckBox> Checkboxlist = new List<CheckBox>();
        foreach (CheckBox control in this.Controls.OfType<CheckBox>())
        {
            Checkboxlist.Add(control);
            control.Checked = false;
        }
   
        for (int i = 0; i <= 200; i++)
        {
            var r = random.Next(0, Checkboxlist.Count);
            var checkbox = Checkboxlist[r];
                checkbox.Checked = true;
        }
    }
