       private void btnGuess_Click(object sender, EventArgs e)
        {
            string guess = txtGuess.Text;
            string[] words = new string[6] { "word1", "word2", "word3", "word4", "word5", "word6" }; //<--| initialize words array
            lstWords.Items.Add(txtEnterWord.Text); //<--| what is that for?
            string randWord = GetRandomWord(words); //<--| get rabdom word from words array
            if (String.Equals(guess, randWord))
            {
                MessageBox.Show("Congratulations you have won! Your words are a match");
            }
            else
            {
                MessageBox.Show("Sorry but your words are not a match, try again");
            }
        }
        static private string GetRandomWord(string[] words)
        {
            Random rnd = new Random();
            return words[rnd.Next(0, words.Length)].ToString();
        }
