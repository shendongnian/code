    private void btnAddRow_Click(object sender, EventArgs e)
    {
        var nSkill = new NewSkillRow();
        nSkill.Location = new Point(75, y += 125);
        Controls.Add(nSkill);
    }
