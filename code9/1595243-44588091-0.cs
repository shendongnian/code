    private string regexOp(string sentence, string word, string wordtoReplace, bool isRemove)
        {
            var retValue = sentence;
            if (isRemove)
            {
                var Pattern = "^.*?(?=" + word + ")";
                Match result = Regex.Match(sentence, @Pattern);
                if (!string.IsNullOrEmpty(result.Value))
                {
                    retValue = result + wordtoReplace;
                }
            }
            else
            {
                retValue = Regex.Replace(sentence, word, wordtoReplace);
            }
            return retValue;
        }
