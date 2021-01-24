            [Test]
            public void Test()
            {
                var result = NewSentenceWithUpperLetter("Sentence one. sentence two.");
                // result will be 'Sentence one. Sentence two.'
            }
    
            private string NewSentenceWithUpperLetter(string text)
            {
                var splitted = text.Split(' ');
                for (var i = 1; i < splitted.Length; i++)
                {
                    if (splitted[i - 1].EndsWith("."))
                    {
                        splitted[i] = splitted[i][0].ToString().ToUpper() + splitted[i].Substring(1);
                    }
                }
    
                return string.Join(" ", splitted);
            }
