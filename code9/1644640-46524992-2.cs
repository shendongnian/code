        private void guessBtn_Click(object sender, EventArgs e)
        {
            char[] randomCharArray = randomInput.ToLowerInvariant().ToCharArray();
            char[] userInputArray = userInput.ToLowerInvariant().ToCharArray();
            //Assume that userInput would never be superior than randomCharArray
            //And contain only one char
            for (int i = 0; i < randomCharArray.Length; i++)
            {
                if (randomCharArray[i] == userInputArray[0])
                {
                    MessageBox.Show("Hi");
                }
            }
           // Clean userInput in form
           userInputBox.Text = "";
        }
