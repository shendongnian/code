    private void SkillNumericUpDown_Enter(object sender, EventArgs e)
    {
       var skill = (NumericUpDown)sender;
       var totalPoints = 42; // total points which are available for user
       var maxSkillPoints = 20; // usually you cannot assign all points to one skill
       var unassignedPoints = totalPoints - SkillPointsAssigned + skill.Value;
       skill.Maximum = Math.Min(maxSkillPoints, unassignedPoints);
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
