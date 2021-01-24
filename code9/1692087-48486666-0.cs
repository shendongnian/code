            string wordSplitCount = Microsoft.VisualBasic.Interaction.InputBox("Word split count", "Enter word split count", "2");
            int wordSplitC = 0;
            int.TryParse(wordSplitCount, out wordSplitC);
            this.richTextBox1.Enabled = false;
            if (wordSplitC > 0)
            {
                List<string> WordList = new List<string>();
                List<string> LineList = this.richTextBox1.Text.Split('\n').ToList();
                LineList.Select((Line, Index) => new { Line, Index }).ToList().ForEach(Item =>
                {
                    string[] Words = Item.Line.Split(' ').ToArray();
                    List<string> CombinedWords = Words.Where((word, index) => index + wordSplitC <= Words.Length).Select((word, index) => String.Join(" ", Words.Skip(index).Take(wordSplitC).Select(r => removeTurkishCharacters(r).Trim()))).ToList();
                    LineList.RemoveAll(x => CombinedWords.Any(c => removeTurkishCharacters(x).Contains(removeTurkishCharacters(c))) && x != Item.Line);
                });
                this.richTextBox2.Text = string.Join("\n", LineList);
                this.richTextBox1.Enabled = true;
            }
