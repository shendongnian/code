    private void SkillNumericUpDown_Enter(object sender, EventArgs e)
    {
       var skill = (NumericUpDown)sender;
       var availablePoints = 42;
       var maxSkillPoints = 20; // usually you cannot assign all points to one skill
       var unassignedPoints = availablePoints - SkillPointsAssigned;
       skill.Maximum = Math.Min(maxSkillPoints, unassignedPoints  + skill.Value);
       if (unassignedPoints == 0)
       {
           MessageBox.Show("You are out of points!");
           return;
       }
       if (skill.Value == maxSkillPoints)
       {
           MessageBox.Show("Skill maximized!");
           return;
       }
    }
    private decimal SkillPointsAssigned =>
        CMB_num_Aim.Value + 
        CMB_num_Reflexes.Value + 
        CMB_num_Positioning.Value + 
        CMB_num_Movement.Value + 
        CMB_num_Teamwork.Value;
