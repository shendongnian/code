    private void ToggleCheck(object sender, EventArgs e)
    {              
          List<CheckBox> Cons = new List<CheckBox>(){CheckBox1, CheckBox2, CheckBox3};       
          int score = 0;
          foreach(CheckBox cb in Cons)
                    score += cb.Checked == true ? 1 : 0;  
          myButton.Enabled = (score >= 2); 
    }
