    if (UI_TB_UserInput.Text.Length > 0)
        {
        char min = UI_TB_UserInput.Text[0];
        char max = UI_TB_UserInput.Text[0];
            foreach (char c in UI_TB_UserInput.Text)
            {
                if (c < min)
                {
                    min = c;
                }
                if (c > max)
                {
                    max = c;
                }
                if (UI_RB_Min.Checked)
                {
                    UI_LB_MinMaxOutput.Text = min.ToString();
                }
                else
                {
                    UI_LB_MinMaxOutput.Text = max.ToString();
                }
            }
        }
        else
        {
            UI_LB_MinMaxOutput.Text = "";//If not > 0 then display blank
        }
