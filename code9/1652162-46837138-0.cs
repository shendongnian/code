     // It would return true if you word count is greater than 0 and less or equal to 50
     private bool WordCount_EH(bool WordCount_Bool)
     {
          var splittedWords = input_box.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
          return (splittedWords.Count >= 0 && splittedWords.Count <= 50);
     }
