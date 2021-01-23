        private static bool CalculateConditionForLowerCase(string stringLetter)
        {
            return stringLetter.ToLower() == "k";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                return;
            }
            var caretPosition = textBox1.SelectionStart;
            var sb = new StringBuilder();
            foreach (var letter in textBox1.Text)
            {
                var stringLetter = letter.ToString();
                sb.Append(CalculateConditionForLowerCase(stringLetter) ? stringLetter.ToLower() : stringLetter.ToUpper());
            }
            textBox1.Text = sb.ToString();
            textBox1.SelectionStart = caretPosition;
        }
