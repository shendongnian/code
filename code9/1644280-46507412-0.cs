    private void guessBtn_Click(object sender, EventArgs e)
        {
            char[] currentWordCharArray = currentWord.ToCharArray();
            char[] userGuessCharArray = userInputBox.Text.ToCharArray();
            int lengthOfAnswer = currentWordCharArray.Length;
            List<char> progressInformer = new List<char>();
            for (int i = 0; i < lengthOfAnswer; i++)
            {
                if (i < userGuessCharArray.Length)
                {
                    if (currentWordCharArray[i] == userGuessCharArray[i])
                    {
                        progressInformer.Add(currentWordCharArray[i]);
                    }
                    else
                    {
                        progressInformer.Add('*');
                    }
                }
                else
                {
                    progressInformer.Add('*');
                }
            }
        }
