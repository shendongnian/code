        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            string userInput = textBox1.Text;
            int sum = 0;
            if (IsAllLetters(userInput) == true)
            {
                for (int i = 0; i < userInput.Length; i++)
                {
                    sum += (int)char.GetNumericValue(userInput[i]);
                }
                label2.Text = "Summa:               " + sum;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Delete all letters??", "Alert", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    userInput = Regex.Replace(userInput, "[^0-9]+", string.Empty);
                    for (int i = 0; i < textBox1.Text.Length; i++)
                    {
                        sum += (int)char.GetNumericValue(textBox1.Text[i]);
                    }
                    label2.Text = "Summa:               " + sum;
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
        }
        public static bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (Char.IsLetter(c))
                    return false;
            }
            return true;
        }
