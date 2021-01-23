        public void Calculate()
        {
            foreach(string sentence in sentenceList)
            {
                sentences++;
                for (int i = 0; i < sentence.Length; i++)
                {
                    if (vowelsArray.Contains(sentence[i]))
                    {
                        vowels++;
                    }
                    else if (consonantsArray.Contains(sentence[i]))
                    {
                        consonants++;
                    }
                    // the else was removed here!
                    if (char.IsUpper(sentence[i]))
                    {
                        upperCaseLetters++;
                    }
                    else if (char.IsLower(sentence[i]))
                    {
                        lowerCaseLetters++;
                    }
                }
            }
        }
