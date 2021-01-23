      private void RegHomePhoneTBox_TextChanged(object sender, EventArgs e)
        {
            string s = RegHomePhoneTBox.Text;
            if (s.Length == 7)
            {
               double sAsD = double.Parse(s);
               RegHomePhoneTBox.Text = string.Format("{0:###-####}", sAsD).ToString();
            }
            if (RegHomePhoneTBox.Text.Length > 1)
                 RegHomePhoneTBox.SelectionStart = RegHomePhoneTBox.Text.Length;
            RegHomePhoneTBox.SelectionLength = 0;
        }
