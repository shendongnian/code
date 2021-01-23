    private void button1_Click(object sender, EventArgs e)
    {
      if (UI_TB_UserInput.Text.Length > 0)
      {
        string inputString = UI_TB_UserInput.Text;
        char[] charArray = inputString.ToCharArray();
        Array.Sort(charArray);
        Array.Reverse(charArray);
        UI_LB_MinMaxOutput.Text = charArray[0].ToString();
      }
    }
