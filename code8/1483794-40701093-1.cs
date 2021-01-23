        public static void ExtractWordsWithSameLetters(string text, List<string> listOfWords)
        {
            string firstWord = null;
            string secondWord = null;
            for (var i = 0; i < listOfWords.Count - 1; i++)
            {
                var textCopy = text;
                var firstWordIsMatched = true;
                foreach (var letter in listOfWords[i])
                {
                    var pattern = $"(.*?)({letter})(.*?)";
                    var regex = new Regex(pattern);
                    if (regex.IsMatch(text))
                    {
                        textCopy = regex.Replace(textCopy, "$1*$3", 1);
                    }
                    else
                    {
                        firstWordIsMatched = false;
                        break;
                    }
                }
                if (!firstWordIsMatched)
                {
                    continue;
                }
                firstWord = listOfWords[i];
                for (var j = i + 1; j < listOfWords.Count; j++)
                {
                    var secondWordIsMatched = true;
                    foreach (var letter in listOfWords[j])
                    {
                        var pattern = $"(.*?)({letter})(.*?)";
                        var regex = new Regex(pattern);
                        if (regex.IsMatch(text))
                        {
                            textCopy = regex.Replace(textCopy, "$1*$3", 1);
                        }
                        else
                        {
                            secondWordIsMatched = false;
                            break;
                        }
                    }
                    if (secondWordIsMatched)
                    {
                        secondWord = listOfWords[j];
                        break;
                    }
                }
                if (secondWord == null)
                {
                    firstWord = null;
                }
                else
                {
                    //if (textCopy.ToCharArray().Any(l => l != '*'))
                    //{
                    //    break;
                    //}
                    break;
                }
            }
            if (firstWord != null)
            {
                Console.WriteLine($"{firstWord} { secondWord}");
            }
        }
